using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 2.0f;

    private bool movingToB = true;
    private SpriteRenderer SpriteRenderer;


    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (movingToB)
        {
            // Di chuyển từ A đến B
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToB = false;
                SpriteRenderer.flipX = !SpriteRenderer.flipX;
            }
        }
        else
        {
            // Di chuyển từ B đến A
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToB = true;
                SpriteRenderer.flipX = !SpriteRenderer.flipX;
            }
        }
    }
}
