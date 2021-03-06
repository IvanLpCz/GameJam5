using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    private collisions coll;
    [Space]
    [Header("Settings")]
    [SerializeField] float rangeDetect = 20f;
    [SerializeField] float attackRange = 15f;
    [SerializeField] float fireRateMin, fireRateMax;
    [SerializeField] float speed = 20f;
    [SerializeField] float speedGuard = 15f;
    [SerializeField] float suspiciousTime = 2f;
    [Range(0, 1)]
    [SerializeField] float soundVolume = 0.7f;
    public string bulletTag;

    [Space]
    [Header("transforms")]
    public Transform aimPos;
    public GameObject target;

    [Space]
    [Header("liveOrNot")]
    public bool isAlive;

    [Space]
    [Header("weapons")]
    public GameObject weaponATK;
    public GameObject weaponIdle;
    public GameObject particleShoot;

    [Space]
    [Header("sounds")]
    public AudioClip alert;
    public AudioClip shoot;
    public AudioClip death;
    public AudioClip walk;

    private bool inRange;
    private bool lookinFor;
    private bool hasShoot;
    private bool firstTimeSeePlayer = true;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private float timeSinceLastAttack;
    private float fireRate;
    private float distanceToPlayer;
    private float playerIsRight;
    private float spawnPointIsRight;

    private Vector3 wayPointPos;
    private Vector3 guardPosition;

    private GameObject wayPoint;
    private Transform body;
    private Animator animController;
    private AudioSource audioS;

    public AudioSource walkingSoruce;
    private void Start()
    {
        isAlive = true;
        guardPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        wayPoint = GameObject.Find("wayPoint");
        coll = GetComponent<collisions>();
        body = GetComponentInChildren<Transform>();
        animController = GetComponentInChildren<Animator>();

        weaponATK.SetActive(true);
        weaponIdle.SetActive(false);
        boxCollider.enabled = true;
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        playerIsRight = (target.transform.position.x - transform.position.x);
        spawnPointIsRight = (guardPosition.x - transform.position.x);
        if (InAttackRangeOfPlayer() && !coll.onGround && !coll.onLeftWall)
        {
            lookinFor = true;
            weaponATK.SetActive(false);
            weaponIdle.SetActive(true);
            animController.SetBool("lookingForPlayer", true);
            StopCoroutine(suspiciousBehaviour());
            if (firstTimeSeePlayer)
            {
                audioS.PlayOneShot(alert, soundVolume);
            }

            firstTimeSeePlayer = false;
        }
        else
        {
            lookinFor = false;
            weaponATK.SetActive(true);
            weaponIdle.SetActive(false);
            animController.SetBool("lookingForPlayer", false);
            StartCoroutine(suspiciousBehaviour());
        }
        if (GetIsInRange() && isAlive)
        {
            inRange = true;
            lookinFor = false;
            checkRotation();
            walkingSoruce.Stop();
        }
        else
        {
            inRange = false;
        }
        if (inRange && isAlive)
        {
            Attack();
            walkingSoruce.Stop();
        }
        if (!hasShoot)
        {
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }
        if (lookinFor && isAlive)
        {
            MovingToTarget();
            checkRotation();
            if(!walkingSoruce.isPlaying)
            {
                walkingSoruce.Play();
            }
        }
        if (!isAlive)
        {
            weaponATK.SetActive(false);
            weaponIdle.SetActive(false);
        }
    }

    private void MovingToTarget()
    {
        animController.SetBool("shooting", false);
        animController.SetBool("lookingForPlayer", true);
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }

    private void Attack()
    {
        hasShoot = true;
        if (timeSinceLastAttack > fireRate)
        {
            particleShoot.SetActive(false);
            PoolBullet();
            animController.SetBool("shooting", true);
        }
    }

    private void PoolBullet()
    {
        GameObject bullet = poolling.SharedInstance.GetPooledObject(bulletTag);

        if (bullet != null)
        {
            particleShoot.SetActive(true);
            bullet.transform.position = aimPos.position;
            bullet.transform.rotation = aimPos.rotation;
            audioS.PlayOneShot(shoot, soundVolume);
            bullet.SetActive(true);
        }
        timeSinceLastAttack = 0f;
        hasShoot = false;
    }

    private bool InAttackRangeOfPlayer()
    {
        distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        return distanceToPlayer < rangeDetect;
    }

    private void checkRotation()
    {
        if (playerIsRight >= 0)
        {
            body.transform.rotation = new Quaternion(body.rotation.x, 180, body.rotation.z, body.rotation.w);
        }
        else if (playerIsRight < 0)
        {
            body.transform.rotation = new Quaternion(body.rotation.x, 0, body.rotation.z, body.rotation.w);
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < attackRange;
    }
    private void BackToNormal()
    {
        if (!lookinFor && !inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, guardPosition, speedGuard * Time.deltaTime);
            animController.SetBool("backToGuard", true);
            if (!walkingSoruce.isPlaying)
            {
                walkingSoruce.Play();
            }
        }
        if(transform.position == guardPosition)
        {
            animController.SetBool("backToGuard", false);
            walkingSoruce.Stop();
        }
    }
    IEnumerator suspiciousBehaviour()
    {
        yield return new WaitForSeconds(suspiciousTime);
        if (lookinFor || inRange)
        {
            yield break;
        }
        BackToNormal();
        RotateSpawn();
    }

    private void RotateSpawn()
    {
        if (!lookinFor && !inRange)
        {
            if (spawnPointIsRight >= 0)
            {
                body.transform.rotation = new Quaternion(body.rotation.x, 180, body.rotation.z, body.rotation.w);
            }
            else if (spawnPointIsRight < 0)
            {
                body.transform.rotation = new Quaternion(body.rotation.x, 0, body.rotation.z, body.rotation.w);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeDetect);

    }
    IEnumerator dying()
    {
        bool diying = false;
        if (!diying)
        {
            audioS.PlayOneShot(death, soundVolume);
            diying = true;
        }
        animController.SetTrigger("die");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isAlive = false;
        StartCoroutine(dying());
        boxCollider.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        StartCoroutine(dying());
        boxCollider.enabled = false;
    }
}
