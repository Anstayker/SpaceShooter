using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
    public float xMin, xMax, yMin, yMax;
}


public class PlayerMovement : MonoBehaviour {
    
    [Header("Movement")]
    [SerializeField] private float acceleration = 1.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    [Header("Rotation")] 
    [SerializeField] private float controlRollFactor = 20.0f;

    private float xThrow = 0.0f, yThrow = 0.0f;
    
    private Rigidbody _rigidbody;
    private InputManager _playerInput;
    private Vector3 _movement;
    public Boundary boundary;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<InputManager>();
    }

    private void FixedUpdate() {
        ProcessMovement(_playerInput.InputMovement);
        ProcessRotation();
        _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(_rigidbody.position.y, boundary.yMin, boundary.yMax), 0f);
    }

    private void ProcessMovement(Vector3 inputMovement) {
        xThrow = inputMovement.x;
        yThrow = inputMovement.y;
        _movement = new Vector3(
            xThrow * acceleration,
            yThrow * acceleration,
            0);
        
        _rigidbody.velocity = _movement;

        if (_rigidbody.velocity.magnitude > maxSpeed) {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
        }
    }

    private void ProcessRotation() {
        
        float roll = -xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(0, roll, 0);
        
    }
}
