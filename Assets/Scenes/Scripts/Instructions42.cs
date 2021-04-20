using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions42 : MonoBehaviour
{
    
    public GameObject uiObject2;
    public GameObject uiObject3;
    public GameObject uiObject4;
    // Start is called before the first frame update
    void Start()
    {
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Subject42")
        {
            
            uiObject2.SetActive(true);
            uiObject3.SetActive(true);
            uiObject4.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {

        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);
    }
}   