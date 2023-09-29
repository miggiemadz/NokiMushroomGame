using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator animator;
    [SerializeField] public SpriteRenderer sprite;

    // horizontal movement
    public float walkSpeed;
    private float direction;
    private bool isFacingRight;

    // verticle movement
    public float jumpSpeed;
    public float fallMultiplier;
    public float JumpTimeStart;
    private float jumpTimer;
    private bool isJumping;
    public float peakHeightMult;
    private float coyoteTimeCounter;
    public float coyoteTime;

    // wall sliding
    private bool isWallSliding;
    public float wallSlidingSpeed;

    // wall jumping
    private bool isWallJumping;
    private float wallJumpingDirection;
    public float wallJumpingTime;
    private float wallJumpingCounter;
    public float wallJumpingDuration;
    public float wallJumpingSpeedX;
    public float wallJumpingSpeedY;


    //Wall Checks
    [SerializeField] public Transform wallCheck;
    [SerializeField] public LayerMask wallLayer;

    //Ground Checks
    [SerializeField] public Transform feetPosition;
    public float groundCheckRadius;
    [SerializeField] public LayerMask groundCheckLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        animator.SetFloat("Movement_Speed", Mathf.Abs(rb.velocity.x));

        direction = Input.GetAxisRaw("Horizontal");


        Jump();

        WallSlide();

        WallJump();

        Flip();

        rb.velocity = new Vector2((walkSpeed * direction), rb.velocity.y);
    }


    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(feetPosition.position, groundCheckRadius, groundCheckLayer);
    }

    private void Jump()
    {
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpSpeed;
            jumpTimer = JumpTimeStart;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimer > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            rb.velocity = Vector2.up * peakHeightMult;
        }

        if (rb.velocity.y < 0f)
        {
            rb.velocity -= Vector2.up * fallMultiplier * Time.deltaTime;
            if (rb.velocity.y < -50f)
            {
                rb.velocity = Vector2.up * -50f;
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && direction > 0f || !isFacingRight && direction < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingSpeedX, wallJumpingSpeedY);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }

    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void WallSlide()
    {
        if (isWalled() && !isGrounded() && direction != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
            rb.velocity -= Vector2.up * fallMultiplier * Time.deltaTime;
        }
    }

}

