using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Attackable : MonoBehaviour
{
    private Health myHealth;
    private Rigidbody2D rb;
    private SpriteRenderer spr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        myHealth = GetComponent<Health>(); //Each attackable object will have his own health (baseHealth and currentHealth)
    }

    public void Attacked(Vector2 attackDirection, int damage)
    { 
        StartCoroutine(TakeDamage(damage));
        rb.AddForce(attackDirection * damage * 150, ForceMode2D.Impulse); //When attacked, the object will be pushed back as well
    }

    //Coroutinesç
    IEnumerator TakeDamage(int damage)
    {
        myHealth.ModifyHealth(-damage); //When attacked, the object will lose 1HP
        spr.color = Color.red;
        TextHitGenerator.sharedInstance.CreateTextHit(Color.red, this.transform, -damage);
        yield return new WaitForSeconds(0.15f);
        spr.color = Color.white;
    }
}
