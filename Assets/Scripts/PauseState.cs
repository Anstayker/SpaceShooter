
public class PauseState : State {

    private Pause _pause;
    private bool _isGamePaused;
    
    public PauseState(GameManager gameManager) : base(gameManager) {
        _pause = ((GameManager) StateMachine).pause;
        _isGamePaused = false;
    }

    public override void Enter() {
        _isGamePaused = true;
        _pause.InPause(_isGamePaused);
    }

    public override void UpdateLogic() {
        //TODO me voy a playing
    }

    public override void Exit() {
        _isGamePaused = false;
        _pause.InPause(_isGamePaused);
    }
}