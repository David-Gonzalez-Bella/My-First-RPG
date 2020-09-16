using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner sharedInstance { get; private set; }
    public Enemy[] enemies;
    public GameObject spawnEffect;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void InstantiateSpawnEffect(Enemy enemy)
    {
        Instantiate(spawnEffect, enemy.transform.position + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
        AudioManager.sharedInstance.OnEnemySpawnSound += PlaySpawnSound;
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            InstantiateSpawnEffect(enemies[i]);  
        }

        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i], this.transform);
        }
    }

    public void PlaySpawnSound()
    {
        AudioManager.sharedInstance.enemySpawn.Play();
        AudioManager.sharedInstance.OnEnemySpawnSound -= PlaySpawnSound;
    }
}
