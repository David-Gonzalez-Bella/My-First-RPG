using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner sharedInstance;
    public Enemy [] enemies;
    public GameObject spawnEffect;

    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void InstantiateSpawnEffect(Enemy enemy)
    {
        Instantiate(spawnEffect, enemy.transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            InstantiateSpawnEffect(enemies[i]);
        }
        
        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i], this.transform);
        }   
    }
}
