using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float horizontal; // allows horizontal movement
    private float moveSpeed = 10f; // movement speed
    private float jumpForce = 8f; // amount of force behind each jump
    private int jumpCount;
    private int maxJumpCount = 1;
    private bool isFacingRight = true; // checks if the player char is looking left or right
    private bool canDash = true; // allows dash functionality
    private bool isDashing; // checks if player is dashing
    private float dashForce = 24f; // amount of force behind each dash
    private float dashingTime = 0.2f; // amount of time player can spend dashing
    private float dashingCooldown = 1f; // cooldown for dashing
    #endregion
    #region SerializeF
    [SerializeField] private Rigidbody2D rb; // holds rigidbody
    [SerializeField] private Transform groundCheck; // holds groundcheck for jumps
    [SerializeField] private LayerMask groundLayer; // Lets you use Layers
    [SerializeField] private TrailRenderer tr; // holds trail renderer 
    #endregion

    private void Start()
    {
        jumpCount = maxJumpCount; // sets the amount of jumps the player can do
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal"); // allows for horizontal movement using A and D

        if (Input.GetButtonDown("Jump") && jumpCount > 0) // makes the player jump or double jump if they can
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }

        if (Input.GetKeyDown(KeyCode.E) && canDash) // makes the player dash
        {
            StartCoroutine(Dash());
        }

        if(IsGrounded()) // if the player has hit the ground, jump count resets so they can jump again
        {
            jumpCount = maxJumpCount;
        }

        Flip(); // calls flip function
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // checks to see if the ground is within range and can reset jumps
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) // allows for the player char to flip 
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash() // turns off base gravity, allows for a horizontal dash, then resumes standard gravity. has 1 second cooldown
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
