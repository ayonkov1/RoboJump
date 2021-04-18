using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    Rigidbody2D rb;

    public int maxJumps = 1;
    public int jumpCount;
    public float jumpCooldown;
    bool isGrounded;

    public float jumpForce = 8f;

    public Transform feet;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            jumpCooldown = 0;
            
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
            jumpCooldown = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            FindObjectOfType<AudioManager>().Play("DoubleJump");
        }

        CheckGrounded();
    }
}
