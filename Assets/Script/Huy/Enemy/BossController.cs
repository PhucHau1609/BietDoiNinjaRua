using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    public float stoppingDistance = 1.5f;
    [SerializeField] float timeDelayTakeDamage = 0.5f;
    [SerializeField] float timeDelayAttack = 1f;

    private bool isFlipped = false; 
    private Animator animator;
    private bool canWalk = true;
    private bool canAttak = true;

    private Vector3 originalScale;

    void Start()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale; 
    }

    void Update()
    {
        MoveTowardsPlayer();
        FlipSprite();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bulet"))
        {
            animator.SetTrigger("Hit");
            // khi nhan damage enemy tam dung
            StartCoroutine(BossStopWalk());
        }
    
    }


    void MoveTowardsPlayer()
    {
        float horizontalDistance = Mathf.Abs(player.position.x - transform.position.x);

        if (horizontalDistance > stoppingDistance && canWalk)
        {
            animator.SetBool("Walk", true);

            Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
            Vector2 movePosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, movePosition, Time.deltaTime * moveSpeed);
        }
        else
        {

            animator.SetBool("Walk", false);
  
        }

        if (horizontalDistance < stoppingDistance && canAttak)
        {
            canAttak = false;
            StartCoroutine(BossAttak());
        }

        if (Boss2.currenHeartEnemies < 1)
        {
            animator.SetBool("Death", true);
        }
    }

    void FlipSprite()
    {
        if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            isFlipped = true;
        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = originalScale;
            isFlipped = false;
        }
    }

    private IEnumerator BossStopWalk()
    {
        canWalk = false;
        yield return new WaitForSeconds(timeDelayTakeDamage);
        canWalk = true;

    }

    private IEnumerator BossAttak()
    {
        canWalk = false;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(timeDelayAttack);
        canWalk = true;
        canAttak = true;

    }

}
