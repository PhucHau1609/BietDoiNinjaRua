using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMoving : MonoBehaviour
{
    [SerializeField] float movespeed = 1.0f;
    Rigidbody2D rigibody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigibody2d.velocity = new Vector2(movespeed, 0f);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        movespeed = -movespeed;
        FlipEnemiesFacing();
    }
    void FlipEnemiesFacing()
    {
        transform.localScale = new Vector2(4 * -(Mathf.Sign(rigibody2d.velocity.x)),4f);
    }    
}
