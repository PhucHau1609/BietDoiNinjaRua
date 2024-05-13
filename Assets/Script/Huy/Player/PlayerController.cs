using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        Run();
        Flip();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);

        Animation();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            // do stuff
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
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
