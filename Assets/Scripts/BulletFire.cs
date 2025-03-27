using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float bulletSpeed = 10f;

    [Range(1, 10)]
    [SerializeField] private float bulletLifetime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, bulletLifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

     
}
