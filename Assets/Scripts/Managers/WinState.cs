
using UnityEngine;

public class WinState : State {

    private GameObject _winUI;

    public WinState(GameManager gameManager) : base(gameManager) {
        _winUI = ((GameManager) StateMachine).winUI;
    }

    public override void Enter() {
        _winUI.SetActive(true);
    }
    
}