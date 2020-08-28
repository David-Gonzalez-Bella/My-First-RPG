using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputEnemy))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Attackable))]

public class EnemyKnight : Enemy //Enemy inherits from Monobehaviour. Therefore, so does EnemyKnight
{
    public GameObject swordFlash;

    public override void EnemyAttack() //The knight overrides the method to attack, as he attacks in his own way
    {
        atk.PhysicalAttack(attackDirection, atrib.damage, swordFlash);
    }
    public override void FlipSprite() //Each enemy will flip his sprite in his own way, depending on the direction his sprite sheets look at
    {
        if (input.horizontalDir < 0)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false;
        }
    }
}
