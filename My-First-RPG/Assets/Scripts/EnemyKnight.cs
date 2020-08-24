using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : Enemy //Enemy inherits from Monobehaviour. Therefore, so does EnemyKnight
{
    private InputEnemy input;
    private Attack atk; //The EnemyKnight can attack our player
    private Animator anim;
    private SpriteRenderer spr;

    private int attackHash;
    private int deadHash;
    private int blockHash;
    private int walkHash;

    private bool attacking = false;
    private bool inCombat = false;
    private bool dead = false;
    private Vector2 attackDirection;

    [SerializeField] private float detectionDistance; //From this distance on, the enemy will detect the player
    [SerializeField] private float attackingDistance; //From this distance on, the enemy will attack the player

    private void Awake()
    {
        input = this.GetComponent<InputEnemy>(); //Now the EnemyKnight knows the direction of the players, in other words, the player´s position regarding its own
        atk = this.GetComponent<Attack>();
        anim = this.GetComponent<Animator>();
        spr = this.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        attackHash = Animator.StringToHash("Attack");
        deadHash = Animator.StringToHash("Dead");
        blockHash = Animator.StringToHash("Block");
        walkHash = Animator.StringToHash("Walk");
    }

    private void Update()
    {
        Behaviour(); //The knight´s behaviour will be checked every frame
    }
    private void Behaviour()
    {
        if (!dead)
        {
            if (!attacking && input.distanceMagnitude < attackingDistance) //If the enemy is not attacking and the distance to the player is less than the attacking distance it means that he shall attack the player
            {
                attackDirection = input.playerDirection; //Just when the knight decides to attack the direction he is facing will be decided
                inCombat = true;
                attacking = true;
                FlipSprite();
                anim.SetTrigger(attackHash);
                anim.SetBool(walkHash, false);
            }
            else if (!attacking && (/*inCombat ||*/ input.distanceMagnitude < detectionDistance))
            {
                anim.SetBool(walkHash, true);
                ChasePlayer();
            }
        }
    }

    private void ChasePlayer()
    {
        FlipSprite();
        this.transform.position += (Vector3)input.playerDirection * atrib.speed * Time.deltaTime;
    }

    public void EnemyAttack() //Called during the attack animation
    {
        atk.ActionAttack(attackDirection, atrib.damage); //the direction of the attack was decided previously so he knight cant correct the way he is looking during his attack in the middle of the animation
    }

    private void FlipSprite()
    {
        if (input.horizontalDir < 0) { spr.flipX = true; }
        else { spr.flipX = false; }
    }

    public void EndAttack()
    {
        attacking = false;
    }
}
