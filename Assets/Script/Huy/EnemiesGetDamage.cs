using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesGetDamage : MonoBehaviour
{
    [SerializeField] float heartEnemies;
    [SerializeField] float currenHeartEnemies;
    [SerializeField] Slider heartBar;
    [SerializeField] ParticleSystem enemyGetDamageFx;

    private void Start()
    {
        heartBar.maxValue = heartEnemies;
        currenHeartEnemies = heartEnemies;
    }

    private void Update()
    {
        heartBar.value = currenHeartEnemies;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bulet"))
        {
            enemyGetDamageFx.Play();
            currenHeartEnemies -= BuletSC.damageBulet;
            if (currenHeartEnemies <= 0)
            {
                Destroy(gameObject);

            }
        }
    }
}
