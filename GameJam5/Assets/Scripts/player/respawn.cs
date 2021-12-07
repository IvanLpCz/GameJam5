using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public playerController controller;
    public GameObject player;
    private Vector3 respawnPoint;
    [SerializeField] private int dyingTime;

    private void Start()
    {
        respawnPoint = transform.position;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bulletTest")
        {
            controller.isAlive = false;
            controller.canMove = false;
            StartCoroutine(dieAnimation());
        }
        if (other.tag == "spikes")
        {
            controller.isAlive = false;
            controller.canMove = false;
            StartCoroutine(dieAnimation());
        }
        else if(other.tag == "checkPoint")
        {
            respawnPoint = transform.position;
        }
    }
    IEnumerator dieAnimation()
    {
        yield return new WaitForSeconds(dyingTime);
        player.transform.position = respawnPoint;
        controller.isAlive = true;
        controller.canMove = true;
    }
}
