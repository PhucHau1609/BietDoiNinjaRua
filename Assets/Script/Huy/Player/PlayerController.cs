using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float doubleJumpSpeed = 5f; 
    [SerializeField] private int maxJumps = 2;

    public static float runSpeed = 6f;
    public static float runSpeedStart;
    private int jumpCount = 0;
    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private CapsuleCollider2D myCapsuleCollider;
    private float gravityScaleAtStart;


    void Start()
    {
        runSpeedStart = runSpeed;
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        Run();
        Flip();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
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
        if (collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Trap")
            || collision.gameObject.CompareTag("InWater"))
        {
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("InWater"))
        {
            
        }
    }

    void ClimbLadder()
    {

        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("IdleClimbing", false);
            myAnimator.SetBool("IsClimbing", false);
            return;
        }

        myAnimator.SetBool("IdleClimbing", true);
        if (moveInput.y != 0)
        {
            myAnimator.SetBool("IsClimbing", true);
            myAnimator.SetBool("IdleClimbing", false);
        }
        else
        {
            myAnimator.SetBool("IsClimbing", false);
        }

        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BackGround"))

        myRigidbody.gravityScale = gravityScaleAtStart;
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

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

  
}
