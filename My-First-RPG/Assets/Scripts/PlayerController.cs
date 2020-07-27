using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveX;
    private float moveY;
    private Vector2 movement;
    //private Vector2 newPosition;

    Rigidbody2D rb;

    private float speed = 4.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = InputPlayer.sharedInstance.horizontal;
        moveY = InputPlayer.sharedInstance.vertical;
    }
    private void FixedUpdate()
    {
        //newPosition = transform.position + new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
        movement = new Vector2(moveX, moveY) * speed; //* Time.deltaTime; -> Here i dont multiply by Time.deltaTime, as i am change the rigidbody´s velocity directly. It is not a manual update of the position, as i was doing before
        rb.velocity = movement; /*transform.position = newPosition;*/
    }
}
