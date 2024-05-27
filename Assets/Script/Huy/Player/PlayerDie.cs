
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float timeLoadGameOverPlayerDied;

    private Vector2 startCheckPoint;

    private void Start()
    {
        startCheckPoint = Player.transform.position;
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
        if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Enemy")
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        //StartCoroutine(WayPlayerDied());

        Player.transform.position = startCheckPoint;

        if (GameManager.Instance.GetHeart() >= 1)
        {
            GameManager.Instance.SetHeart(GameManager.Instance.GetHeart() - 1);
        }
    }

    private IEnumerator GameOver()
    {
        //crossFadeNextLevel.SetTrigger("Start");
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        yield return new WaitForSeconds(timeLoadGameOverPlayerDied);
        Destroy(Player);
        SceneManager.LoadScene("GameOver");
    }
}