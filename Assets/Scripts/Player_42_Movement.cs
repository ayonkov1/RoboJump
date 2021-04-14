using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_42_Movement : MonoBehaviour
{
    float xinput, yinput;

    public float moveSpeed = 0.2f;

    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per fram

    void FixedUpdate()
    {
        xinput = Input.GetAxis("Subject42");

        transform.Translate(xinput * moveSpeed, yinput * moveSpeed, 0);


        PlatformerMove();
        FlipPlayer();
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xinput, rb.velocity.y);
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
}
