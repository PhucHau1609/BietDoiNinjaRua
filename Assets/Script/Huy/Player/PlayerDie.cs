using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator aniPlayer;
    [SerializeField] float timeReTakeDamage;
    [SerializeField] float timeLoadGameOverPlayerDied;

    [Header("Damage: ")]
    [SerializeField] int damageTrap = 1;
    [SerializeField] int damageEnamy = 1;

    private Vector2 startCheckPoint;
    bool isTouchTrap;

    private void Start()
    {
        startCheckPoint = player.transform.position;
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
        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Water")
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
            isTouchTrap = false;
        }
    }

    private IEnumerator PlayerReceiveDamage(int damage)
    {

        Debug.Log("Touch Trap: " + isTouchTrap);
        while (isTouchTrap)
        {
            Debug.Log("Is Work");
            GameManager.Instance.ReceiveDamage(damage);
            aniPlayer.SetBool("ReceiveDamage", true);
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