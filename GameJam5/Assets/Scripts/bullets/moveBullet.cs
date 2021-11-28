using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 50f;
    public float angularVelocity = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = angularVelocity;
        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deflect"))
        {
            rb.AddForce(transform.right * -bulletSpeed * 2, ForceMode2D.Impulse);
        }
        else
        {
            gameObject.SetActive(false);
        }      
    }
}
