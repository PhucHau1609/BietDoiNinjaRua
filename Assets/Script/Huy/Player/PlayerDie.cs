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
    [SerializeField] CapsuleCollider2D capsuleCollider;

    private Vector2 startCheckPoint;
    bool isTouchTrap;

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
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
        if (collision.gameObject.tag == "Trap"
            || collision.gameObject.tag == "Water"
            || collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(PlayerReceiveDamage());
            isTouchTrap = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            isTouchTrap = false;
        }
    }

    private IEnumerator PlayerReceiveDamage()
    {

        Debug.Log("Touch Trap: " + isTouchTrap);
        while (isTouchTrap)
        {
            Debug.Log("Is Work");
            GameManager.Instance.ReceiveDamage(1);
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