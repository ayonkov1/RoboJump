﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Subject42"))
        {
            SceneManager.LoadScene(0);

            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }
}
