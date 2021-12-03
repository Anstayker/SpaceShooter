using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private GameObject cameraLimit;

    private Vector3 _cameraLimitPosition;
    private GameManager _gameManager;
    
    [HideInInspector] public bool winGame = false;
    
    private void Start() {
        _gameManager = FindObjectOfType<GameManager>();
        _cameraLimitPosition = cameraLimit.transform.position;
    }

    private void Update() {
        ProcessMovement();
    }

    private void ProcessMovement() {
        if (transform.position.y <= _cameraLimitPosition.y) {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
        }
        else {
            winGame = true;
        }
    }
    
    
    
}
