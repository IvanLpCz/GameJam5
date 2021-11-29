using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    [Space]
    [Header("Settings")]
    [SerializeField] float rangeDetect = 20f;
    [SerializeField] float attackRange = 15f;
    [SerializeField] float fireRateMin, fireRateMax;

    [Space]
    [Header("transforms")]
    public Transform aimPos;
    public GameObject target;
   
    private bool inRange;
    private bool movingToTarget;
    private bool hasShoot;

    private float timeSinceLastAttack;
    private float fireRate;

    private Vector3 guardPosition;

    private void Start()
    {
        guardPosition = transform.position;
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (InAttackRangeOfPlayer())
        {
            movingToTarget = true;
        }
        else
        {
            BackToNormal();
        }
        if (GetIsInRange())
        {
            inRange = true;
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
    }

    private void Attack()
    {
        hasShoot = true;
        print(fireRate);
        if (timeSinceLastAttack > fireRate)
        {
            PoolBullet();
        }
    }

    private void PoolBullet()
    {
        GameObject bullet = poolling.SharedInstance.GetPooledObject("bulletTest");

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
        float distanceToPlayer = Vector3.Distance(target.transform.position, transform.position);
        return distanceToPlayer < rangeDetect;
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
