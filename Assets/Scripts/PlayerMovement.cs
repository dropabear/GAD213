using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public float dashForce;
    public float jumpForce;
    public float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isDashing = false;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private bool isGrounded;
    public float checkRadius;
    private int jumpCount;
    public int maxJumpCount;
    #endregion

    private void Start()
    {
        jumpCount = maxJumpCount;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput();

        Animate();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded )
        {
            jumpCount = maxJumpCount;
        }
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("jump force applied");
            jumpCount--;
        }
        isJumping = false;

        if(isDashing == true)
        {
            rb.AddForce(new Vector2(dashForce, 0f));
        }
        isDashing = false;
    }

    private void PlayerInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
        }
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipPlayer();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
