using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int scene = SceneManager.GetActiveScene().buildIndex;
        

        if (collision.CompareTag("Subject42") || collision.CompareTag("SubjectX"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            SceneManager.LoadScene(scene);
        }
    }
}
