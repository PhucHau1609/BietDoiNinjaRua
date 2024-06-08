using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletSC : MonoBehaviour
{
    [SerializeField] float buletSpeed = 8f;
    [SerializeField] float buletTimeDestroy = 2f;
    [SerializeField] float setDamageBulet = 10;
    public static float damageBulet;
    private Vector2 moveBulet;
    private SpriteRenderer spBulet;

    void Start()
    {
        damageBulet = setDamageBulet;
        Destroy(gameObject, buletTimeDestroy);
        moveBulet = PlayerDie.isLeft ? Vector2.left : Vector2.right;
        spBulet = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        transform.Translate(moveBulet * buletSpeed * Time.deltaTime);
        if (moveBulet == Vector2.left)
        {
            spBulet.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("IsWork0");
            Destroy(gameObject);

        }
    }

}
