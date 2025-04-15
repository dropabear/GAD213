using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletKillsEnemy : CombatManager
{
    public GameObject Enemy;
    public int deadEnemies = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Bullet hit Enemy");

                Enemy = other.gameObject; // Assign the object to Enemy

                deadEnemies++;

                Destroy(Enemy);
            }
        }

    private void Update()
    {
        if (deadEnemies == maxNumOfEnemies)
        {
            NextScene();
        }
    }

    public void NextScene() //use this on the button
    {
        currentScene++; //add 1
       
        SceneManager.LoadScene(currentScene);
    }
}
