
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float doubleJumpSpeed = 5f; 
    [SerializeField] private int maxJumps = 2;

    private int jumpCount = 0;
    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Animation();
        Flip();
        Climping();
    }

    void OnJump(InputValue value)
    {
        //if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}
        if (value.isPressed && jumpCount < maxJumps)
        {
            if (jumpCount == 0)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
            else
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, doubleJumpSpeed);

            jumpCount++; 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    void Climping()
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climping"))) { return; }
        Debug.Log("Climping IsWork");

    }

    void Animation()
    {
        if (moveInput.x != 0)
        {
            myAnimator.SetBool("IsRunning", true);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }
    }

    void Flip()
    {
        if (moveInput.x == -1)
        {
            mySpriteRenderer.flipX = true;
        }
        else if (moveInput.x == 1)
        {
            mySpriteRenderer.flipX = false;
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
}
