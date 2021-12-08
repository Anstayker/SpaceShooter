using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine {

    [HideInInspector] public PlayingState playingState;
    [HideInInspector] public PauseState pauseState;
    [HideInInspector] public GameOverState gameOverState;
    [HideInInspector] public WinState winState;

    public GameObject player;
    public CameraMovement MainCamera;
    public Pause pause;
    public GameObject winUI;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public PlayerHealth playerHealth;

    private void Awake() {
        playerHealth = player.GetComponent<PlayerHealth>();
        inputManager = player.GetComponent<InputManager>();
        
        playingState = new PlayingState(this);
        pauseState = new PauseState(this);
        gameOverState = new GameOverState(this);
        winState = new WinState(this);
    }

    protected override State GetInitialState() {
        return playingState;
    }
}
