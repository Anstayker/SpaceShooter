using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State {

    private PlayerHealth _playerHealth;
    private GameObject _player;
    private float _startTime = 0.0f;
    
    public GameOverState(GameManager gameManager) : base(gameManager) {
        _player = ((GameManager) StateMachine).player;
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    public override void Enter() {
        _player.SetActive(false);
        _startTime = Time.time;
    }

    public override void UpdateLogic() {
        if (Time.time - _startTime > _playerHealth.respawnDelay) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}