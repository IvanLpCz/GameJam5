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
    public string bulletTag;

    [Space]
    [Header("transforms")]
    public Transform aimPos;
    public GameObject target;
   
    private bool inRange;
    private bool loockinFor;
    private bool hasShoot;
    private bool canWalk;

    private Rigidbody2D rb;

    private float timeSinceLastAttack;
    private float fireRate;
    private float distanceToPlayer;

    private Vector3 wayPointPos;
    private Vector3 guardPosition;
    private Vector3 playerIsRight;

    private GameObject wayPoint;
    private Transform body;

    private void Start()
    {
        guardPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        wayPoint = GameObject.Find("wayPoint");
        coll = GetComponent<collisions>();
        body = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        playerIsRight = (target.transform.position - transform.position);
        if (InAttackRangeOfPlayer() && !coll.onRightWall && !coll.onLeftWall)
        {
            loockinFor = true;
        }
        else
        {
            BackToNormal();
            loockinFor = false;
        }
        if (GetIsInRange())
        {
            inRange = true;
            loockinFor = false;
        }
        else
        {
            inRange = false;
        }
        if (inRange)
        {
            Attack();
        }
        if (!hasShoot)
        {
            fireRate = Random.Range(fireRateMin, fireRateMax);
        }
        if (loockinFor)
        {
            MovingToTarget();
            checkRotation();
        }
    }

    private void MovingToTarget()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, speed * Time.deltaTime);
        print("distance to target" + distanceToPlayer);
    }

    private void Attack()
    {
        hasShoot = true;
        if (timeSinceLastAttack > fireRate)
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
        if (playerIsRight.x < 0)
        {
            new Quaternion(body.rotation.x, 180, body.rotation.z, body.rotation.w);
        }
        else if (playerIsRight.x >= 0)
        {
            new Quaternion(body.rotation.x, 0, body.rotation.z, body.rotation.w);
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < attackRange;
    }
    private void BackToNormal()
    {
        Vector3 nextPosition = guardPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeDetect);

    }
}
