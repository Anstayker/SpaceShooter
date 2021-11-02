using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public List<GameObject> path;

    [SerializeField] private float movementSpeed = 100.0f;
    [SerializeField] private float movementPrecision = 10.0f;
    
    private Rigidbody _rigidbody;
    [SerializeField] private int _waypointIndex = 0;
    [SerializeField] private Transform _currentWaypoint;
    
    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _currentWaypoint = path[_waypointIndex].transform;
    }

    private void FixedUpdate() {
        if (Vector3.Distance(transform.position, _currentWaypoint.position) < movementPrecision) {
            if ((_waypointIndex + 1) < path.Count) {
                _currentWaypoint = path[_waypointIndex + 1].transform;
                _waypointIndex++;
            }
            else {
                Destroy(gameObject);
            }
        }
        else {
            _rigidbody.velocity = (_currentWaypoint.position - transform.position).normalized * movementSpeed;
        }
    }
}
