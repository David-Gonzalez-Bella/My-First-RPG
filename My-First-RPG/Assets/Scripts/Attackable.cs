using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Attackable : MonoBehaviour
{
    private Health myHealth;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        myHealth = GetComponent<Health>(); //Each attackable object will have his own health (baseHealth and currentHealth)
    }

    public void Attacked()
    {
        myHealth.CurrentHealth -= 1; //When attacked, the object will lose 1HP
        Debug.Log("My Current Health is: " + myHealth.CurrentHealth.ToString());
    }

    public void Attacked(Vector2 attackDirection, int damage)
    {
        myHealth.ModifyHealth(-damage); //When attacked, the object will lose 1HP
        rb.AddForce(attackDirection * damage * 175, ForceMode2D.Impulse); //When attacked, the object will be pusshed back as well
    }
}
