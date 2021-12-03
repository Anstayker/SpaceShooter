using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine {

    [HideInInspector] public PlayingState playingState;
    [HideInInspector] public PauseState pauseState;
    [HideInInspector] public GameOverState gameOverState;

    public Pause pause;
    public GameObject player;

    [HideInInspector] public PlayerHealth playerHealth;

    private void Awake() {
        playingState = new PlayingState(this);
        pauseState = new PauseState(this);
        gameOverState = new GameOverState(this);

        playerHealth = player.GetComponent<PlayerHealth>();
    }

    protected override State GetInitialState() {
        return playingState;
    }
}
