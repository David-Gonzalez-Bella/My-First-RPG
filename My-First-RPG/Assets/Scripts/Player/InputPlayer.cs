﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public static InputPlayer sharedInstance; //Singleton

    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool basicAtk { get; private set; }
    public bool ability1 { get; private set; }
    public bool ability2 { get; private set; }
    public bool interact { get; private set; }
    public bool inventary { get; private set; }

    [HideInInspector] public Vector2 faceDirection = new Vector2(0.0f, -1.0f); //Initial direction we are facing

    private void Awake()
    {
        sharedInstance = this;
    }

    void Update()
    {
        //Player movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Actions
        basicAtk = Input.GetButtonDown("Basic Attack");
        ability1 = Input.GetButtonDown("Ability 1");
        ability2 = Input.GetButtonDown("Ability 2");
        interact = Input.GetButtonDown("Interact");
        inventary = Input.GetButtonDown("Inventary");

        //Face Direction
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) //If we move we update the direction we are facing
        {
            faceDirection.x = horizontal;
            faceDirection.y = vertical;
        }
    }
}