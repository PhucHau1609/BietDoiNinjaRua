using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    [Header("Set")]
    [SerializeField] float heartEnemies;
    [SerializeField] float showCurrenHeartEnemies;
    [SerializeField] float timeDestroyObj = 0.5f;
    [SerializeField] float gravityScaleDie = 1;
    //[SerializeField] float deathDelayTime = 0.5f;

    [Header("Get")]
    [SerializeField] Slider heartBarYellow;
    [SerializeField] Slider heartBarRed;
    [SerializeField] ParticleSystem enemyGetDamageFx;

    public static float currenHeartEnemies;

    private void Awake()
    {
        showCurrenHeartEnemies = heartEnemies;
        currenHeartEnemies = showCurrenHeartEnemies;
    }

    private void Start()
    {
        heartBarYellow.maxValue = heartEnemies;
        heartBarRed.maxValue = heartEnemies/2;
    }

    private void Update()
    {
        currenHeartEnemies = showCurrenHeartEnemies;
        heartBarYellow.value = showCurrenHeartEnemies;
        heartBarRed.value = showCurrenHeartEnemies;
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
        //// Tắt tất cả các Collider2D
        //Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        //foreach (Collider2D collider in colliders)
        //{
        //    collider.enabled = false;
        //}
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
        // Nếu có bất kỳ script điều khiển chuyển động nào, hãy vô hiệu hóa nó

        var movementScript = GetComponent<EnemyMoving>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }

        //SaveData.Instance.AddDataPlayer();
        ClockController.Instance.StopTime();
        ClockController.Instance.ResetTime();
        GameManager.Instance.Reset();

        Destroy(gameObject, timeDestroyObj);
        SceneManager.LoadScene("WinScene");
    }
}
