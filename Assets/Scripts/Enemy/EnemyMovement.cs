using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public List<GameObject> path;

    [SerializeField] private float movementSpeed = 100.0f;
    [SerializeField] private float movementPrecision = 10.0f;
    
    private Rigidbody _rigidbody;
    [SerializeField] private int waypointIndex = 0;
    [SerializeField] private Transform currentWaypoint;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        currentWaypoint = path[waypointIndex].transform;
    }

    private void FixedUpdate() {
        MoveEnemy();
    }
    private void MoveEnemy() {
        if (Vector3.Distance(transform.position, currentWaypoint.position) < movementPrecision) {
            if ((waypointIndex + 1) < path.Count) {
                currentWaypoint = path[waypointIndex + 1].transform;
                waypointIndex++;
            }
            else {
                Destroy(gameObject);
            }
        }
        else {
            _rigidbody.velocity = (currentWaypoint.position - transform.position).normalized * movementSpeed;
        }
    }
}
