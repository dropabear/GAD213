using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Variables 
    public Transform[] waypoints; // Holds my waypoints 
    public float speed = 5f; // Speed of movement
    private int currentWaypointIndex = 0;
    #endregion
    // Variables relating to the car movement

    void Update()
    {
        if (waypoints.Length == 0) return; // Exit if no waypoints

        Transform targetWaypoint = waypoints[currentWaypointIndex]; // Chooses next waypoint in index
        Vector3 directionToWaypoint = (targetWaypoint.position - transform.position).normalized; // Targets selected waypoint for movement

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step); // Sets speed and moves object towards waypoin
    }
}
