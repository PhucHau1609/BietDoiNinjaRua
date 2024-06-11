
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesGetDamage : MonoBehaviour
{
    [Header("Set")]
    [SerializeField] float heartEnemies;
    [SerializeField] float showCurrenHeartEnemies;
    [SerializeField] float timeDestroyObj = 0.5f;
    [SerializeField] float gravityScaleDie = 1;
    //[SerializeField] float deathDelayTime = 0.5f;

    [Header("Get")]
    [SerializeField] Slider heartBar;
    [SerializeField] ParticleSystem enemyGetDamageFx;
    [SerializeField] Rigidbody2D rigiEnemyDie;

    public static float currenHeartEnemies;

    private void Awake()
    {
        showCurrenHeartEnemies = heartEnemies;
    }

    private void Start()
    {
        heartBar.maxValue = heartEnemies;
    }

    private void Update()
    {
        currenHeartEnemies = showCurrenHeartEnemies;
        heartBar.value = showCurrenHeartEnemies;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bulet"))
        {
            enemyGetDamageFx.Play();
            showCurrenHeartEnemies -= BuletSC.damageBulet;
            if (showCurrenHeartEnemies <= 0)
            {
                EnemiesDie();
            }
        }
    }

    private void EnemiesDie()
    {
        rigiEnemyDie.gravityScale = gravityScaleDie;

        // Tắt tất cả các Collider2D
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        // Nếu có bất kỳ script điều khiển chuyển động nào, hãy vô hiệu hóa nó
        var movementScript = GetComponent<EnemyMoving>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }

        Destroy(gameObject, timeDestroyObj);
    }
}
