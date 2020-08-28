using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //This contains the IA and the atributes every enemy will have
{
    public Atributes atrib; //Evey enemy has his basic atributes (for a more specific one they'll have them in their own script)
    public int exp;

    protected InputEnemy input;
    protected Attack atk; //The EnemyKnight can attack our player
    protected Animator anim;
    protected SpriteRenderer spr;
    protected CapsuleCollider2D col;

    private int attackHash;
    private int deadHash;
    //private int blockHash;
    private int walkHash;

    private bool attacking = false;
    //private bool inCombat = false;
    private bool dead = false;
    protected Vector2 attackDirection;

    [SerializeField] private float detectionDistance; //From this distance on, the enemy will detect the player
    [SerializeField] private float attackingDistance; //From this distance on, the enemy will attack the player

    private void Awake()
    {
        input = this.GetComponent<InputEnemy>(); //Now the EnemyKnight knows the direction of the players, in other words, the player´s position regarding its own
        atk = this.GetComponent<Attack>();
        anim = this.GetComponent<Animator>();
        col = this.GetComponent<CapsuleCollider2D>();
        spr = this.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        attackHash = Animator.StringToHash("Attack");
        deadHash = Animator.StringToHash("Dead");
        walkHash = Animator.StringToHash("Walk");
        //blockHash = Animator.StringToHash("Block");
    }

    private void Update() //Every enemy shall check its behaviour every frame
    {
        Behaviour(); //The knight´s behaviour will be checked every frame
    }
    protected void Behaviour()
    {
        if (!dead)
        {
            if (!attacking && input.distanceMagnitude < attackingDistance) //If the enemy is not attacking and the distance to the player is less than the attacking distance it means that he shall attack the player
            {
                AttackPlayer();
            }
            else if (!attacking && (/*inCombat ||*/ input.distanceMagnitude < detectionDistance))
            {
                ChasePlayer();
            }
            else //If the player is out of range he goes to idle animation
            {
                anim.SetBool(walkHash, false);
            }
        }
    }

    private void AttackPlayer()
    {
        int attackChance = Random.Range(0, 100);
        anim.SetBool(walkHash, false); //When the enemy is in attacking state he will stop walking
        if (attackChance > 95) //The chance has to be very low, because this method is executing a lot of times per frame, so we must discriminate a lot of numbers
        {
            attackDirection = input.playerDirection; //Just when the knight decides to attack the direction he is facing will be decided
            //inCombat = true;
            attacking = true;
            FlipSprite();
            anim.SetTrigger(attackHash);
        }
    }

    private void ChasePlayer()
    {
        anim.SetBool(walkHash, true);
        FlipSprite();
        this.transform.position += (Vector3)input.playerDirection * atrib.speed * Time.deltaTime;
    }

    //Virtual methods
    public virtual void EnemyAttack() { } //Called during the attack animation (each enemy will attack in his own way)

    public virtual void FlipSprite() { } //Each enemy will flip his sprite in his own way, depending on the direction his sprite sheets look at

    public void EndAttack()
    {
        attacking = false;
    }

    public void DissappearEffect()
    {
        EnemySpawner.sharedInstance.InstantiateSpawnEffect(this);
    }

    public void Die() //This function will be called in the "Health" script, thanks to the Unity Event
    {
        dead = true;
        col.enabled = false;
        anim.SetBool(deadHash, true); //This triggers the animation, and on the last frame the character will be destroyed (so did we configured it in the animator interface)
    }
}

