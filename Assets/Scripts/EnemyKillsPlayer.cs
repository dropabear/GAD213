using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyKillsPlayer : MonoBehaviour
{
    public Button restartLevel;
    public TextMeshProUGUI deathText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object entering the trigger is the player
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Enemy was made");

            // Trigger game over sequence
            GameOver();
        }
    }

    private void Start()
    {
        restartLevel.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    void GameOver()
    {
        // Pause the game
        Time.timeScale = 0;
        Debug.Log("Game Over!");
        Instantiate(restartLevel.gameObject, gameObject.transform);
        restartLevel.gameObject.SetActive(true);
        deathText.gameObject.SetActive(true);
    }
}

