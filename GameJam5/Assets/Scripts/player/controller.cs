using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private collisions coll;
    private Rigidbody2D rb;
    public float speed = 10f;
    public float jumpForce = 50f;
    public float slideSpeed = 5f;
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;

    void Start()
    {
        coll = GetComponent<collisions>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        walk(dir);
        if (Input.GetButtonDown("Jump"))
        {
            if (coll.onGround)
            {
                Jump();
            }   
        }
        if(coll.onWall && !coll.onGround)
        {
            wallSlide();
        }
        wallGrab = coll.onWall && Input.GetKey(KeyCode.LeftShift);
        if (wallGrab)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed);
        }
    }

    private void walk(Vector2 dir)
    {
        if (!wallJumped)
        {
            rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), .5f * Time.deltaTime);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }
    private void wallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, - slideSpeed);
    }
}
