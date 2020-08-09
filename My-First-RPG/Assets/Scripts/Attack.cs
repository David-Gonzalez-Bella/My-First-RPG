using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float range = 1.0f; //Range of our attacks ("length of the sword")
    public Vector2 hitbox = new Vector2(1, 1); //Total rectangle that defines the hitbox of our attack

    public void ActionAttack(Vector2 attackDirection, float damage)
    {
        Vector2 sizeScale = transform.lossyScale; //We have to scale the size of our hitbox so it adjusts to the size of our character (it is way better that the hitbox depends on the size of the character, just in case that we change his size for some reason)
        Vector2 scaledHitbox = Vector2.Scale(hitbox, sizeScale);
        Vector2 attackVector = Vector2.Scale(attackDirection.normalized * range, sizeScale); //attackDirection is normalized cause we only want its direction. Its lenght is defined by the variable "range"
        Vector2 A = (Vector2)transform.position + attackVector - scaledHitbox * 0.5f; //Left down dot in our hitbox
        Vector2 B = A + scaledHitbox; //Right top dot in our hitbox

        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVector, Color.red);
        Debug.DrawLine(A, B, Color.yellow);
    }
}
