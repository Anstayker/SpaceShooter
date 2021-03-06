using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerMovement : MonoBehaviour {
    
    [Header("Movement")]
    [SerializeField] private float acceleration = 1.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    [Header("Rotation")] 
    [SerializeField] private float controlRollFactor = 20.0f;

    [SerializeField] private Camera mainCamera;
    
    private float _xThrow = 0.0f, _zThrow = 0.0f;

    public Text score;
    public int contador;
    
    private Rigidbody _rigidbody;
    private InputManager _playerInput;
    private Vector3 _movement;
    public Boundary boundary;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<InputManager>();
        contador = 0;
	    score.text = "Score: " + contador;
    }

    private void FixedUpdate() {
        ProcessMovement(_playerInput.inputMovement);
        ProcessRotation();
        ProcessBoundary();
    }

    private void ProcessMovement(Vector3 inputMovement) {
        _xThrow = inputMovement.x;
        _zThrow = inputMovement.y;
        _movement = new Vector3(
            _xThrow * acceleration,
            0,
            _zThrow * acceleration);
        
        _rigidbody.velocity = _movement;

        if (_rigidbody.velocity.magnitude > maxSpeed) {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
        }
    }

    private void ProcessRotation() {
        float roll = -_xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(0, 0, roll);
    }

    private void ProcessBoundary() {
        Vector3 cameraPosition = mainCamera.transform.position;
        float processedZMin = boundary.zMin + cameraPosition.z;
        float processedZMax = boundary.zMax + cameraPosition.z;
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            20.0f,
            Mathf.Clamp(transform.position.z, processedZMin, processedZMax));
    }

}
