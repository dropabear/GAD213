using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillsEnemy : MonoBehaviour
{
    public GameObject Enemy;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Bullet hit Enemy");

                Enemy = other.gameObject; // Assign the object to Enemy

                Enemy.gameObject.SetActive(false); // now you can disable it

                StartCoroutine(EnemyRespawn());
            }
        }

        private IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(2);
        Enemy.gameObject.SetActive(true);
    }
}
