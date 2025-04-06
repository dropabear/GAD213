using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeath : EnemyKillsPlayer
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object entering the trigger is the player
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Collision with DeathZone was made");

            // Trigger game over sequence
            GameOver();
        }
    }
}
