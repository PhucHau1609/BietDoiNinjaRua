using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesGetDamage : MonoBehaviour
{
    [SerializeField] float heartEnemies;
    [SerializeField] float currenHeartEnemies;
    [SerializeField] Slider heartBar;

    private void Start()
    {
        heartBar.maxValue = heartEnemies;
        currenHeartEnemies = heartEnemies;
    }

    private void Update()
    {
        heartBar.value = currenHeartEnemies;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("IsWork1");
    //    if (collision.gameObject.CompareTag("Bulet"))
    //    {
    //        Debug.Log("IsWork1.1");
    //        currenHeartEnemies -= BuletSC.damageBulet;
    //        if (heartEnemies <= 0)
    //        {
    //            Destroy(gameObject);

    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bulet"))
        {
            currenHeartEnemies -= BuletSC.damageBulet;
            if (currenHeartEnemies <= 0)
            {
                Destroy(gameObject);

            }
        }
    }
}
