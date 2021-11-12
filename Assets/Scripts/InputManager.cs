using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    public Vector3 InputMovement { get; private set; }
    
    private Vector2 _rawInputMovement;
    private PlayerShot _playerShot;
    private bool _isPlayerShooting = false;
    private bool backspace;
    private Pause _pause;

    private void Awake() {
        _playerShot = gameObject.GetComponent<PlayerShot>();
        _pause=gameObject.GetComponent<Pause>();
    }

    public void OnMovement(InputAction.CallbackContext value) {
        _rawInputMovement = value.ReadValue<Vector2>();
        InputMovement = new Vector3(
            _rawInputMovement.x,
            _rawInputMovement.y,
            0);
    }

    public void OnShoot(InputAction.CallbackContext value) {
        _isPlayerShooting = value.ReadValueAsButton();
        _playerShot.ProcessShoot(_isPlayerShooting);
    }

    public void OnPause(InputAction.CallbackContext value){
	backspace=value.ReadValueAsButton();
	
	_pause.InPause(backspace);
	}

}
