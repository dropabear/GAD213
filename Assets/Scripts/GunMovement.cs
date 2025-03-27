using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Transform playerTransform; // Reference to the player's transform
    private bool isFacingRight; // Track if the player is facing right or left
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerTransform = transform.parent; // Assuming the gun is a child of the player object
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        // Adjust the rotation based on whether the player is facing left or right
        if (!isFacingRight)
        {
            rotZ = 180f + rotZ; // Flip the gun's rotation when facing left
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // This method should be called when the player flips
    public void SetPlayerFacingDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
