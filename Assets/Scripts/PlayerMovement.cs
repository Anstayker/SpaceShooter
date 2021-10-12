using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float acceleration = 1.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    private Rigidbody _rigidbody;
    private InputManager _playerInput;
    private Vector3 _movement;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<InputManager>();
    }

    private void FixedUpdate() {
        ProcessMovement(_playerInput.InputMovement);
    }

    private void ProcessMovement(Vector3 inputMovement) {
        
        _movement = new Vector3(
            inputMovement.x * acceleration,
            inputMovement.y * acceleration,
            0);
        
        _rigidbody.AddForce(_movement);

        if (_rigidbody.velocity.magnitude > maxSpeed) {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
