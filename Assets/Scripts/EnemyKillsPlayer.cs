using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKillsPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player triggered the enemy!");

            // Trigger game over sequence
            GameOver();
        }
    }

    void GameOver()
    {
        // Pause the game
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }
}

