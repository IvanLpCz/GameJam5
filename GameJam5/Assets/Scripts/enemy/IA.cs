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
    public string bulletTag;

    [Space]
    [Header("transforms")]
    public Transform aimPos;
    public GameObject target;

    [Space]
    [Header("liveOrNot")]
    public bool isAlive;
   
    private bool inRange;
    private bool lookinFor;
    private bool hasShoot;

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

    private void Start()
    {
        isAlive = true;
        guardPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        wayPoint = GameObject.Find("wayPoint");
        coll = GetComponent<collisions>();
        body = GetComponentInChildren<Transform>();


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
            StopCoroutine(suspiciousBehaviour());
        }
        else
        {
            lookinFor = false;
            StartCoroutine(suspiciousBehaviour());
        }
        if (GetIsInRange() && isAlive)
        {
            inRange = true;
            lookinFor = false;
            checkRotation();
        }
        else
        {
            inRange = false;
        }
        if (inRange && isAlive)
        {
            Attack();
        }
        if (!hasShoot)
        {
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }
        if (lookinFor && isAlive)
        {
            MovingToTarget();
            checkRotation();
        }
    }

    private void MovingToTarget()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }

    private void Attack()
    {
        hasShoot = true;
        if (timeSinceLastAttack > fireRate && isAlive)
        {
            PoolBullet();
        }
    }

    private void PoolBullet()
    {
        GameObject bullet = poolling.SharedInstance.GetPooledObject(bulletTag);

        if (bullet != null)
        {
            bullet.transform.position = aimPos.position;
            bullet.transform.rotation = aimPos.rotation;
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
