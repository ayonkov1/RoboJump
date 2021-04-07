using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{

    public float speed = 10.4f;

    private bool jumping;
    private bool firstRun = true;
    private float jumpingStart;
    private float lastY;
    private float step;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (jumping)
        {
            if (pos.y < jumpingStart + step)
            {
                jumping = false;
            }
            else
            {
                pos.y += speed * Time.deltaTime;
            }
            
        }
        else
        {
            if (Input.GetKey("space"))
            {
                jumping = true;
                jumpingStart = pos.y;
                pos.y += speed * Time.deltaTime;
                step = speed * Time.deltaTime;
            }
        }

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;

        if (lastY >= pos.y && firstRun == false)
        {
            jumping = false;
        }
        lastY = pos.y;
        firstRun = false;
    }
}
