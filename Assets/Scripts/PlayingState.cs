
using UnityEngine;

public class PlayingState : State {

    private InputManager _inputManager;
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private CameraMovement _cameraMovement;
    
    public PlayingState(GameManager gameManager) : base(gameManager) {
        _inputManager = ((GameManager) StateMachine).inputManager;
        _player = ((GameManager) StateMachine).player;
        _cameraMovement = ((GameManager) StateMachine).MainCamera;
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    public override void UpdateLogic() {
        
        if (!_playerHealth.isPlayerAlive) {
            StateMachine.ChangeState(((GameManager) StateMachine).gameOverState);
        }
        
        if (_inputManager.isGamePaused) {
            StateMachine.ChangeState(((GameManager) StateMachine).pauseState);
        }

        if (_cameraMovement.winGame) {
            StateMachine.ChangeState(((GameManager) StateMachine).winState);
        }
        
    }
    
}
