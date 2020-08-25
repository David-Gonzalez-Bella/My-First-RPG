using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputEnemy))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Attackable))]

public class EnemyWizard : Enemy //Enemy inherits from Monobehaviour. Therefore, so does EnemyWizard
{
    public override void EnemyAttack() //The wizard overrides the method to attack, as he attacks in his own way
    {
        Debug.Log("Fire ball!!");
    }
    public override void FlipSprite() //Each enemy will flip his sprite in his own way, depending on the direction his sprite sheets look at
    {
        if (input.horizontalDir < 0)
        {
            spr.flipX = false;
        }
        else
        {
            spr.flipX = true;
        }
    }
}
