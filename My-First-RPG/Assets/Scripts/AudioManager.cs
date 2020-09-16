﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;

    public AudioSource swordAttack;
    public AudioSource fireballAttack;
    public AudioSource stepsSound;
    public AudioSource backgroundMusic;
    public AudioSource enemyDamage;
    public AudioSource enemySpawn;

    public event Action OnPlaySwordSound;
    public event Action OnPlayFireballSound;
    public event Action OnStepsSound;
    public event Action OnEnemyDamageSound;
    public event Action OnEnemySpawnSound;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Update()
    {
        OnPlaySwordSound?.Invoke();
        OnPlayFireballSound?.Invoke();
        OnStepsSound?.Invoke();
        OnEnemyDamageSound?.Invoke();
        OnEnemySpawnSound?.Invoke();
    }
}
