using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Animator animator;

    //player speeds
    private float horizontal;
    public float playerSpeed;
    public float jumpSpeed;
    public float fallSpeed;
    public float glideSpeed;

    //groundchecks
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    //respawning
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    Vector2 vecGravity;

    private bool isGliding;
    private bool canGlide;

    int maxJump = 2;
    private int jumpCount;
    bool canDoubleJump;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;


    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        canDoubleJump = false;
        rb = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb.freezeRotation = true;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Movement_Speed", Mathf.Abs(rb.velocity.x));

        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }


        if (coyoteTimeCounter > 0f && !Input.GetKey(KeyCode.Space))
        {
            jumpCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {                       
            if (jumpCount < maxJump)
            {
                if (coyoteTimeCounter > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

                    jumpCount += 1;
                }
                else if (!isGrounded() && canDoubleJump && jumpCount < maxJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

                    jumpCount += (maxJump - jumpCount);
                }
                
            }
            
        }

        if(Input.GetKey(KeyCode.Space) && !isGrounded() && canDoubleJump && canGlide)
        {
            isGliding = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (jumpCount == maxJump)
            {
                canGlide = true;
            }

            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);


                if (jumpCount >= maxJump)
                {
                    coyoteTimeCounter = 0f;
                }
            }
            if (isGliding)
            {
                isGliding = false;
                canGlide = false;
            }
        }

        if (rb.velocity.y < 0 && !isGliding)
        {
            rb.velocity -= vecGravity * fallSpeed * Time.deltaTime;
        }

        Glide();

        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(0.2f, .17f, 1);
        }

        if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.2f, .17f, 1);
        }


        rb.velocity = new Vector2((playerSpeed * horizontal), rb.velocity.y);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f ,0.6f), CapsuleDirection2D.Horizontal, 0 ,groundLayer);
    }

    private void Glide()
    {
        if (isGliding)
        {
            rb.gravityScale = 0.5f;
        }
        else if (!isGliding)
        {
            rb.gravityScale = 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            collision.gameObject.SetActive(false);

            canDoubleJump = true;
        }

        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }


}
