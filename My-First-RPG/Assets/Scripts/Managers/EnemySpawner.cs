﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner sharedInstance { get; private set; }
    public GameObject spawnEffect;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }


    public void SpawnEnemy(Enemy enemy, Vector3 position, TriggerSpawner parent)
    {
        StartCoroutine(SpawnEnemyCoroutine(enemy, position, parent));
    }

    public void InstantiateSpawnEffect(Enemy enemy, Vector3 position)
    {
        Instantiate(spawnEffect, position + new Vector3(0f, -0.5f, 0f), Quaternion.identity);
        AudioManager.sharedInstance.OnEnemySpawnSound += PlaySpawnSound;
    }

    IEnumerator SpawnEnemyCoroutine(Enemy enemy, Vector3 position, TriggerSpawner parent)
    {
        InstantiateSpawnEffect(enemy, position);
        yield return new WaitForSeconds(0.7f);
        Instantiate(enemy, position, Quaternion.identity, parent.transform);
    }

    public void PlaySpawnSound()
    {
        AudioManager.sharedInstance.enemySpawn.Play();
        AudioManager.sharedInstance.OnEnemySpawnSound -= PlaySpawnSound;
    }
}
