using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDash : MonoBehaviour
{
    [SerializeField] float speed, delay, delayPress;
    [SerializeField] GameObject particle;
    [HideInInspector] public bool startDelay;
    Rigidbody2D rb;
    int rightPress, leftPress;
    float timePassed, timePassedPress;
    bool startTimer;

    private void Start()
    {
        rightPress = 0;
        leftPress = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftPress++;
            startTimer = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftPress++;
            startTimer = true;
        }
        if (leftPress >= 2 || rightPress >= 2)
        {
            startDelay = true;
            Instantiate(particle, transform, false);
        }
    }

    private void FixedUpdate()
    {
        if (startDelay)
        {
            timePassed += Time.fixedDeltaTime;

            if (timePassed <= delay)
            {
                if (rightPress >= 2)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    rightPress = 0;
                }
            }
            else if (leftPress >= 2)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                rightPress = 0;
            }
        }
        else
        {
            timePassed = 0;
            startDelay = false;
            rightPress = 0;
            leftPress = 0;
        }

    }
}
