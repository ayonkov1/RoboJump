using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_X_Movement : MonoBehaviour
{
    float xinput, yinput;
    bool isDashing;

    public float moveSpeed = 0.2f;

    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        xinput = Input.GetAxis("SubjectX");

        transform.Translate(xinput * moveSpeed, yinput * moveSpeed, 0);

        FlipPlayer();
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
