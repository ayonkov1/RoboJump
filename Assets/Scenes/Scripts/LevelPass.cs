using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (collision.CompareTag("Subject42"))
        {
            Debug.Log("Subjects have entered passing checkpoint!");

            SceneManager.LoadScene(currentScene + 1);

            FindObjectOfType<AudioManager>().Play("LevelPassed");
        }
    }
}
