
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] Animator aniPlayer;
    [SerializeField] float timeReTakeDamage;
    [SerializeField] float timeLoadGameOverPlayerDied;

    [Header("Damage: ")]
    [SerializeField] int damageTrap = 1;
    [SerializeField] int damageWater = 1;
    [SerializeField] int damageEnamy = 1;


    private GameObject player;
    Rigidbody2D playerRigi;
    //private Vector2 startCheckPoint;

    bool isTouchTrap;

    private void Start()
    {
        //startCheckPoint = player.transform.position;
        player = GameObject.Find("Player");
        playerRigi = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (GameManager.Instance.GetHeart() <= 0)
        {
            StartCoroutine(GameOver());
        }
       
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            isTouchTrap = true;
            StartCoroutine(PlayerReceiveDamage(damageTrap));

        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.ReceiveDamage(damageEnamy);
        }

        if (collision.gameObject.tag == "Ground")
        {
            playerRigi.gravityScale = 3;
            playerRigi.drag = 0;
            PlayerController.runSpeed = 6;
            isTouchTrap = false;
        }
    }

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
        }
    }

    private IEnumerator ReceiveDamageInWater(int damage)
    {

        while (isTouchTrap)
        {
            GameManager.Instance.ReceiveDamage(damage);
            yield return new WaitForSeconds(timeReTakeDamage);
            aniPlayer.SetBool("ReceiveDamage", false);
          
        }
    }



    private IEnumerator GameOver()
    {
        //crossFadeNextLevel.SetTrigger("Start");
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        yield return new WaitForSeconds(timeLoadGameOverPlayerDied);
        Destroy(player);
        SceneManager.LoadScene("GameOver");
    }
}