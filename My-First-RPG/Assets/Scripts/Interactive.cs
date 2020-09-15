﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class Interactive : MonoBehaviour, IPointerDownHandler
{
    protected Collider2D col;
    //public UnityEvent OnInteractive;
    public event Action OnInteractive;
    protected PlayerController player;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    public void OnPointerDown(PointerEventData eventData) //The interface´s method must be implemented (ir occurs when we click it)
    {
        foreach (RaycastHit2D interactObj in player.Interactuables())
        {
            if(interactObj.collider.gameObject == this.gameObject) //If this gameObject is within the collection of interactuable objects detected bi the CircleCastAll...
            {
                Interact();
            }
        }   
    }

    public virtual void Interact()
    {
        Debug.Log("Clicking!!");
    }
}