using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float range = 1.2f; //Range of our attacks ("length of the sword")
    public Vector2 hitbox = new Vector2(1, 0.5f); //Total rectangle that defines the hitbox of our attack
    private Vector2 attackVector;
    private Vector2 A, B;
    private Collider2D[] attackableElements = new Collider2D[10]; // We will be able to attack to 10 elements at the same time (its a bit too much, but its a reasonable number as the maximim quantity of elements to process simultaneously) 
    private ContactFilter2D attackableFilter; //This will filter what was inside our hitbox and what was not
    public LayerMask attackableLayer; //Layer where attackable items and characters will be

    private void Start()
    {
        attackableFilter.useLayerMask = true;
        attackableFilter.layerMask = attackableLayer; //We have to say the layer our filter has to "pay attention to", meaning that it will return the number of elements found inside the hitbox
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVector, Color.red);
        Debug.DrawLine(A, B, Color.yellow);
    }

    private void CreateHitbox(Vector2 attackDirection)
    {
        Vector2 sizeScale = transform.lossyScale; //We have to scale the size of our hitbox so it adjusts to the size of our character (it is way better that the hitbox depends on the size of the character, just in case that we change his size for some reason)
        Vector2 scaledHitbox = Vector2.Scale(hitbox, sizeScale);
        attackVector = Vector2.Scale(attackDirection.normalized * range, sizeScale); //attackDirection is normalized cause we only want its direction. Its lenght is defined by the variable "range"
        A = (Vector2)transform.position + attackVector - scaledHitbox * 0.5f; //Left down dot in our hitbox
        B = A + scaledHitbox; //Right top dot in our hitbox
    }

    private void CheckAttacked(Vector2 attackDirection, int damage)
    {
        int numAttackable = Physics2D.OverlapArea(A, B, attackableFilter, attackableElements); //attackableElements has the Collider2Ds found inside de hitmbox, meaning that that array is now filled with the elements that collided with our hitbox (therefore, we dont have to store the return values inside another array)
        for (int i = 0; i < numAttackable; i++)
        {
            if (attackableElements[i].GetComponent<Attackable>() == true)
            {
                attackableElements[i].GetComponent<Attackable>().Attacked(attackDirection, damage);
            }
        }
    }

    public void PhysicalAttack(Vector2 attackDirection, int damage) 
    {
        CreateHitbox(attackDirection);
        CheckAttacked(attackDirection, damage);   
    }
}
