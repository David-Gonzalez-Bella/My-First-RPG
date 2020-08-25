using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]

public class PlayerController : MonoBehaviour
{
    private float moveX;
    private float moveY;
    private Vector2 movement;
    private bool attack;
    private int xHashCode;
    private int yHashCode;
    private int runningHashCode;
    private int attackHashCode;
    //private Vector2 newPosition;

    Rigidbody2D rb;
    Animator anim;

    public Atributes atrib;
    private Attack atck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        atck = GetComponent<Attack>();
    }

    void Start()
    {
        xHashCode = Animator.StringToHash("X"); //Using hash (returns an int) is better than strings, as it is cheaper to compare two ints frame after frame than comparing, with this same frequency, two strings
        yHashCode = Animator.StringToHash("Y");
        runningHashCode = Animator.StringToHash("Running");
        attackHashCode = Animator.StringToHash("Attack");
    }

    void Update()
    {
        moveX = InputPlayer.sharedInstance.horizontal;
        moveY = InputPlayer.sharedInstance.vertical;
        attack = InputPlayer.sharedInstance.basicAtk;

        if (moveX != 0 || moveY != 0) //It will update the state only if the character moves. Otherwise, it will stay in the last state it entered (the knight will look at the direction he was lastly told to move to)
        {
            anim.SetFloat(xHashCode, moveX);
            anim.SetFloat(yHashCode, moveY);
            anim.SetFloat(runningHashCode, Mathf.Abs(moveX) + Mathf.Abs(moveY));
        }
        if (attack) //If we pressed the attack button/s
        {
            //atck.ActionAttack(InputPlayer.sharedInstance.faceDirection, atrib.damage); //This will send the direction we are facing ((1, 0), (0, 1), (-1, 0) or (0, -1))
            anim.SetTrigger(attackHashCode);
        }
    }

    public void AttackAnimEvent() //Called during the attack animation
    {
        atck.PhysicalAttack(InputPlayer.sharedInstance.faceDirection, atrib.damage); //This will send the direction we are facing ((1, 0), (0, 1), (-1, 0) or (0, -1))
    }

    private void FixedUpdate()
    {
        //newPosition = transform.position + new Vector3(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
        movement = new Vector2(moveX, moveY) * atrib.speed; //* Time.deltaTime; -> Here i dont multiply by Time.deltaTime, as i am change the rigidbody´s velocity directly. It is not a manual update of the position, as i was doing before
        rb.velocity = movement; /*transform.position = newPosition;*/
    }
}
