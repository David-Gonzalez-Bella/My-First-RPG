using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Atributes")]
public class Atributes : ScriptableObject //Attributes is only a bunch of data, so theres no need for this class to inherit from MonoBehaviour. Instead it will be an ScriptableObject, so any gameobject can have an "instance" of this data and choose its values for itself
{
    [Tooltip("Character´s speed")]
    public float speed = 4.0f;

    [Tooltip("Character´s damage")]
    public int damage = 1;
}
