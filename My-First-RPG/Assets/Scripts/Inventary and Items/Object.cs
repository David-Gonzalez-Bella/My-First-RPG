using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Object : Interactive //As it inherits from Interactive (a class that inherits from Monobehaviour) we have a problem: Which Start function will take place? This one or the parent´s one? -> This one, so we´ll have to do the stuff we did int the Interactive Start function here
{
    public Item item; //This will have the Item info related to our concrete object
    private SpriteRenderer spr;
    public int quantity = 1; //If the Item is stackeable this variable will increase. Otherwise it will remain as 1 until it is used

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnValidate() //The things written here will happen in the editor, not during runtime
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = item.sprite;
        gameObject.name = item.itemName;
    }
    private void Start() //Only this Start method will take place, because only our object´s start function happens
    {
        spr.sprite = item.sprite;
        gameObject.name = item.itemName;
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void Interact()
    {
        Debug.Log("Interacting with a potion!");
    }
}
