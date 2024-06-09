using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDie : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigiEnemyDie;
    [SerializeField] float gravityScaleDie = 1;


    private void Update()
    {
        EnemyDie();
    }

    public void EnemyDie()
    {
        if (EnemiesGetDamage.enemyDie)
        {
            rigiEnemyDie.gravityScale = gravityScaleDie;
        }

    }



}
