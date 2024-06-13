using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOut : MonoBehaviour
{
 
    public float moveSpeed = 3f;
    public float stoppingDistance = 1.5f;

    private GameObject player;
    private bool isFlipped = false;
    private Animator animator;

    private Vector3 originalScale;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        MoveTowardsPlayer();
        FlipSprite();
    }

    void MoveTowardsPlayer()
    {

        float horizontalDistance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (horizontalDistance > stoppingDistance)
        {
            //animator.SetBool("Walk", true);

            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, 0).normalized;
            Vector2 movePosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, movePosition, Time.deltaTime * moveSpeed);
        }
    }

    void FlipSprite()
    {
        if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            isFlipped = true;
        }
        else if (transform.position.x < player.transform.position.x && isFlipped)
        {
            transform.localScale = originalScale;
            isFlipped = false;
        }
    }
}
