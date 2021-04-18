using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Subject42") || collision.CompareTag("SubjectX"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            SceneManager.LoadScene(0);
            FindObjectOfType<MainMenu>().enabled = false;
            //FindObjectOfType<DeathMenu>().enabled = true;
        }
    }
}
