﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputEnemy))]
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Attackable))]
[RequireComponent(typeof(Proyectile))]

public class EnemyWizard : Enemy //Enemy inherits from Monobehaviour. Therefore, so does EnemyWizard
{
    public Proyectile fireball; //Reference to the Fireball prefab
    public Transform shootOrigin;

    public override void EnemyAttack() //The wizard overrides the method to attack, as he attacks in his own way
    {
        atk.ProyectileAttack(fireball, input.playerDirection, shootOrigin); //Instead of "attackDirection" we send "input.playerDirection" because we want the fireballs to track more than the knight's attacks do
    }

    public override void FlipSprite() //Each enemy will flip his sprite in his own way, depending on the direction his sprite sheets look at
    {
        if (input.horizontalDir < 0 && spr.flipX)
        {
            spr.flipX = false;
            shootOrigin.localPosition *= Vector2.left;
        }
        else if (input.horizontalDir > 0 && !spr.flipX)
        {
            spr.flipX = true;
            shootOrigin.localPosition *= Vector2.left;
        }
        else if (input.horizontalDir > 0 && spr.flipX)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false;
        }
    }
}