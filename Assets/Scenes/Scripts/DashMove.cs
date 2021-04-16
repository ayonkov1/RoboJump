using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public GameObject dashEffect;

    private float lastPressTime;
    float timeSinceLastPress;
    private const float DOUBLE_PRESS_TIME = .2f; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                timeSinceLastPress = Time.time - lastPressTime;
                lastPressTime = Time.time;

                if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    direction = 1;

                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                timeSinceLastPress = Time.time - lastPressTime;
                lastPressTime = Time.time;

                if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 2;
                }
            }
        } else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero; 
            } else
            {
                dashTime -= Time.deltaTime;
               

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                } else if (direction == 2) {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
