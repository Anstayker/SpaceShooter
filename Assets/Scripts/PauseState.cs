
public class PauseState : State {

    private Pause _pause;
    private bool _isGamePaused;
    private InputManager _inputManager;
    
    public PauseState(GameManager gameManager) : base(gameManager) {
        _pause = ((GameManager) StateMachine).pause;
        _inputManager = ((GameManager) StateMachine).inputManager;
        _isGamePaused = false;
    }

    public override void Enter() {
        _isGamePaused = true;
        _pause.InPause(_isGamePaused);
    }

    public override void UpdateLogic() {
        if (!_inputManager.isGamePaused) {
            StateMachine.ChangeState(((GameManager) StateMachine).playingState);
        }
    }

    public override void Exit() {
        _isGamePaused = false;
        _pause.InPause(_isGamePaused);
    }
}