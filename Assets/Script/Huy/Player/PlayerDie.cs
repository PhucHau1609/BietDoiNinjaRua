using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] Animator aniPlayer;
    [SerializeField] float timeReTakeDamage;
    [SerializeField] float timeLoadGameOverPlayerDied;
    [SerializeField] GameObject player;

    [Header("Damage")]
    [SerializeField] int damageTrap = 1;
    [SerializeField] int damageWater = 1;
    [SerializeField] int damageEnemy = 1;
    [SerializeField] int damageBulet = 5;

    [Header("Bulet")]
    [SerializeField] GameObject buletGOJ;

    public static bool isLeft = false;
   
    Rigidbody2D playerRigi;
    private Vector2 startCheckPoint;

    bool isTouchTrap;

    private void Start()
    {
        startCheckPoint = player.transform.position;
        player = GameObject.Find("Player");
        playerRigi = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FireBullet();
        GameOver();
    }

    // player ban dang
    void FireBullet()
    {
        if (PlayerController.climbLadder == false)
        {
            if (GameManager.Instance.GetCountBulet() >= 1 && Input.GetKeyDown(KeyCode.E))
            {
                var player = transform.position;
                player.x = isLeft ? player.x -= 0f : player.x += 0f;
                player.y = isLeft ? player.y -= 0.2f : player.y -= 0.2f;
                GameManager.Instance.SetCountBuletTru(1);
                Instantiate(buletGOJ, player, Quaternion.identity);
                aniPlayer.SetTrigger("Attack");

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isTouchTrap = true;
            StartCoroutine(PlayerReceiveDamage(damageTrap));
        }

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(PlayerReceiveDamageEnemy(damageEnemy));
        }

        if (collision.gameObject.tag == "Ground")
        {
            playerRigi.gravityScale = 3;
            playerRigi.drag = 0;
            PlayerController.runSpeed = 6;
            isTouchTrap = false;
        }

        if (collision.gameObject.tag == "Heart")
        {

        }
    }

    // xu ly playercham vao nuoc
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("InWater");
            playerRigi.gravityScale = 0.5f; // Giảm trọng lực khi vào vùng nước
            PlayerController.runSpeed = 2;
            playerRigi.drag = 5;
            //Debug.Log("In: " + PlayerController.runSpeed);
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("OutWater");
            playerRigi.gravityScale = 3; // Khôi phục trọng lực khi ra khỏi vùng nước
            //Debug.Log("Out: " + PlayerController.runSpeed);
        }
    }

    private IEnumerator PlayerReceiveDamage(int damage)
    {

        while (isTouchTrap)
        {
            GameManager.Instance.ReceiveDamage(damage);
            aniPlayer.SetBool("ReceiveDamage", true);
            yield return new WaitForSeconds(timeReTakeDamage);
            aniPlayer.SetBool("ReceiveDamage", false);
            PlaerDie();
        }

    }

    private IEnumerator PlayerReceiveDamageEnemy(int damage)
    {
        GameManager.Instance.ReceiveDamage(damage);
        aniPlayer.SetBool("ReceiveDamage", true);
        yield return new WaitForSeconds(timeReTakeDamage);
        aniPlayer.SetBool("ReceiveDamage", false);
        PlaerDie();

    }

    private void PlaerDie()
    {
        if (GameManager.Instance.GetHeart() < 1)
        {
            if (GameManager.Instance.GetLife() >= 1)
            {
                GameManager.Instance.SetLifeTru(1);
                player.transform.position = startCheckPoint;
                GameManager.Instance.ResetDie();

            }
        }
    }

    private void GameOver()
    {
        if (GameManager.Instance.GetLife() < 1)
        {
            Destroy(player);
            SceneManager.LoadScene("GameOver");
        }
    }


    //private IEnumerator GameOver()
    //{
    //    //crossFadeNextLevel.SetTrigger("Start");
    //    //FindObjectOfType<AudioManager>().Play("PlayerDeath");
    //    yield return new WaitForSeconds(timeLoadGameOverPlayerDied);
    //    Destroy(player);
    //    SceneManager.LoadScene("GameOver");
    //}
}