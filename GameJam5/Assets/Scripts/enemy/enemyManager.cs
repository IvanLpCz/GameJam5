using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [Space]
    [Header("webo")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] enemySpawn;

    private int numEnemies;
    private playerController playerStatus;
    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<playerController>();
        for (int i = 0; i <= numEnemies; i++)
        {
            enemySpawn[i].position = enemies[i].transform.position;
            print("spawnpoint " + enemySpawn[2]);
        }
    }

    private void Update()
    {
        if (!playerStatus.isAlive)
        {
            ReSpawn();
        }
    }
    void ReSpawn()
    {
        for (int i = 0; i <= numEnemies; i++)
        {
            enemies[i].transform.position = enemySpawn[i].position;
            print("enemyPosition " + enemies[2].transform.position);
            enemies[i].SetActive(true);
            enemies[i].GetComponent<BoxCollider2D>().enabled = true;
            enemies[i].GetComponent<IA>().isAlive = true;
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
