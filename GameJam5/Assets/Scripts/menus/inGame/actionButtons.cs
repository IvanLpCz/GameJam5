using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButtons : MonoBehaviour
{
    public GameObject jump, attack, climb, dash;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "tutoJump")
        {
            jump.SetActive(true);
        }
        if(other.tag == "tutoDash")
        {
            dash.SetActive(true);
        }
        if(other.tag == "tutoAttack")
        {
            attack.SetActive(true);
        }
        if(other.tag == "tutoClimb")
        {
            climb.SetActive(true);
        }
    }
}
