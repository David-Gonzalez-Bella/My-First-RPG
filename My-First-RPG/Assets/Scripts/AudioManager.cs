using System.Collections;
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

    public event Action OnPlaySwordSound;
    public event Action OnPlayFireballSound;
    public event Action OnStepsSound;

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
    }

}
