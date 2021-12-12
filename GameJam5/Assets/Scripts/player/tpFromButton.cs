using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpFromButton : MonoBehaviour
{
    public Transform tpTo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.transform.position = tpTo.position;
        }
    }
}
