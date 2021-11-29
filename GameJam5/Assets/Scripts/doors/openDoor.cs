using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorAnimator.SetTrigger("open");
    }
}
