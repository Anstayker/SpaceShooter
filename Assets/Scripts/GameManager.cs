using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine {

    [HideInInspector] public PlayingState playingState;
    [HideInInspector] public PauseState pauseState;
    [HideInInspector] public GameOverState gameOverState;

    private void Awake() {
        playingState = new PlayingState(this);
        pauseState = new PauseState(this);
        gameOverState = new GameOverState(this);
    }

    protected override State GetInitialState() {
        return playingState;
    }
}
