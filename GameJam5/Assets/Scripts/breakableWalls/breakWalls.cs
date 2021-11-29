using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakWalls : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("breakableWall"))
        {
            collision.gameObject.SetActive(false);
            print("wallbreakable hit");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("breakableWall"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
