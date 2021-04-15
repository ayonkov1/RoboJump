using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    float xinput, yinput;

    Rigidbody2D rb;
    SpriteRenderer sp;

    public int maxJumps = 1;
    public int jumpCount;
    public float jumpCooldown;
    bool isGrounded;

    public float jumpForce = 10f;

    public float dashDistance = 15f;
    bool isDashing;
    float DoubleTapTime;
    KeyCode lastKeyCode;

    public Transform feet;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        /*xinput = Input.GetAxis("Horizontal");
        *//*yinput = Input.GetAxis("Vertical");*//*

        transform.Translate(xinput * moveSpeed, yinput * moveSpeed, 0);*/

        PlayerMoveLeft();
        PlayerMoveRight();
        PlatformerMove();
        FlipPlayer();
    }

    void PlayerMoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.left * moveSpeed;
        } // End of IF Statement
    }// End of PlayerMoveLeft

    void PlayerMoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
    }


    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (isGrounded || jumpCount < maxJumps)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        CheckGrounded();
    }

    void PlatformerMove()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(moveSpeed * xinput, rb.velocity.y);
        }
    }

    void FlipPlayer()
    {
        if (rb.velocity.x < -0.001f)
        {
            sp.flipX = true;
        }
        else if (rb.velocity.x > 0.001f)
        {
            sp.flipX = false;
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance + direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 3f;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}
