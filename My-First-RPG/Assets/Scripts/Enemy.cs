using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Atributes atrib;
    public int exp;
    public string myName;

    protected void SayName()
    {
        Debug.Log("Hi my name is " + myName);
    }
}
