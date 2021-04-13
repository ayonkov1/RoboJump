using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    public float dashDistance = 8f;
    bool isDashing;
    float DoubleTapTime;
    KeyCode lastKeyCode;

    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // Dashing left
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (DoubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
            }
            else
            {
                DoubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.A;
        }

        // Dashing right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (DoubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
            }
            else
            {
                DoubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.D;
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
