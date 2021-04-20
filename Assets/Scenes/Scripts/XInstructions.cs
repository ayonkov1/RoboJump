using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XInstructions : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject uiObject1;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SubjectX")
        {
            uiObject.SetActive(true);
            uiObject1.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        uiObject.SetActive(false);
        uiObject1.SetActive(false);
    }
}
