using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [Space]
    [Header("webo")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] enemySpawn;
    [SerializeField] private int castReSpawnDelay;

    private playerController playerStatus;
    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<playerController>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemySpawn[i].position = enemies[i].transform.position;
            print("number of i on start " + i);

        }
    }

    private void Update()
    {
        if (!playerStatus.isAlive)
        {
            StartCoroutine(delayReSpawn());
        }
    }
    IEnumerator delayReSpawn()
    {
        yield return new WaitForSeconds(castReSpawnDelay);
        ReSpawn();
    }
    void ReSpawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemySpawn[i].position;
            enemies[i].SetActive(true);
            enemies[i].GetComponent<BoxCollider2D>().enabled = true;
            enemies[i].GetComponent<IA>().isAlive = true;
            print("number of i on respawn " + i);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
