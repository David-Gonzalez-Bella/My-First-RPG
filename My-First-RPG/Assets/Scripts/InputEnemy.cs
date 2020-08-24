﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    public Vector2 playerDirection { get; private set; }
    public float horizontalDir
    {
        get
        {
            return playerDirection.x;
        }
    }
    public float verticalDir
    {
        get
        {
            return playerDirection.y;
        }
    }
    public float distanceMagnitude
    {
        get
        {
            return playerDirection.magnitude;
        }
    }

    public Transform playerPos;

    private void Start()
    {
        //playerPos = GameManager.sharedInstance.player.transform; //ERROR due to the scripts execution order (we'll solve it later on)
    }

    private void Update()
    {
        playerDirection = playerPos.position - this.transform.position;
    }
}
