using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMoveJump : MonoBehaviour
{
    public float moveSpeed;
    private float xInput, yInput;

    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField] Transform feet;

    public float jumpForce = 15f;
    public float extraJumps = 1;
    bool isGrounded;
    int jumpCount;
    float jumpCoolDown;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        PlatformerMove();
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
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
        if (isGrounded || jumpCount < extraJumps)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;
        }
    }
}
