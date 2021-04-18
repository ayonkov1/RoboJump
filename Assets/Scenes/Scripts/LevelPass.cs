using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SubjectX") && collision.CompareTag("Subject42"))
        {
            Debug.Log("Subjects have entered passing checkpoint!");

            //SceneManager.LoadScene(2);

            FindObjectOfType<AudioManager>().Play("LevelPassed");
        }
    }
}
