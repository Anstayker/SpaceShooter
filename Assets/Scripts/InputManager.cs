using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    public Vector3 InputMovement { get; private set; }
    
    private Vector2 _rawInputMovement;
    
    public void OnMovement(InputAction.CallbackContext value) {
        _rawInputMovement = value.ReadValue<Vector2>();
        InputMovement = new Vector3(
            _rawInputMovement.x,
            _rawInputMovement.y,
            0);
    }

}
