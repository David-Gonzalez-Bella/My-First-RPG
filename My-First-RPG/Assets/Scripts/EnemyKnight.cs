using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : Enemy //Enemy inherits from Monobehaviour. Therefore, so does EnemyKnight
{
    private InputEnemy input;

    private void Awake()
    {
        input = this.GetComponent<InputEnemy>();
    }

    private void Update()
    {
        this.transform.position += (Vector3)input.playerDirection * atrib.speed * Time.deltaTime;
    }
}
