using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillsEnemy : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit Enemy");

            Enemy.gameObject.SetActive(false);

            StartCoroutine (EnemyRespawn());
        }
    }

    private IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(2);
        Enemy.gameObject.SetActive(true);
    }
}
