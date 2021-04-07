using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce = 10;
    bool isGrounded;
    public Transform feet;
    public LayerMask groundLayer;

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer);
        isGrounded = true;
    }
}
