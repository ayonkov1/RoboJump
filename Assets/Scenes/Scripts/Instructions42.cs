using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions42 : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Subject42")
        {
            uiObject.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        uiObject.SetActive(false);
    }
}   