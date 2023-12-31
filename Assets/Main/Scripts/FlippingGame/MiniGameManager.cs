﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set;  }
    protected enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    protected State state;


    public event EventHandler OnStateChanged; //states of mini game

    public event EventHandler StartGameContent;// catch event start enable minigame

    public event EventHandler OnPauseAction;

    public event EventHandler OnWinChanged;


    protected float waitingToStartTimer = 1f;
    protected float countdownToStartTimer = 3f;
    protected float gamePLayingTimer;
    protected float gamePLayingTimerMax;
    protected bool isGamePause = false;

    [SerializeField] private float easyLevelMaxTime = 5f;
    [SerializeField] private float mediumLevelMaxTime = 30f;
    [SerializeField] private float hardLevelMaxTime = 40f;



    protected int score = 0;
    private void Awake()
    {
        Instance = this;
        
        // Khởi tạo các giá trị khác   
        state = State.WaitingToStart;
    }



    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                    StartGameContent?.Invoke(this, EventArgs.Empty);
                    gamePLayingTimer = getGamePlayingTimerMax();
                }
                break;
            case State.GamePlaying:
                gamePLayingTimer -= Time.deltaTime;
                if (gamePLayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;       
        }
        Debug.Log(state);
 

    }

    public bool IsGameWaiting()
    {
        return state == State.WaitingToStart;
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public bool IsGamePause()
    {
        return isGamePause;
    }

    public  void restartGame()
    {

        waitingToStartTimer = 1f;
        countdownToStartTimer = 3f;
        gamePLayingTimer = 0f;
        isGamePause = false;
        state = State.WaitingToStart;
    }

    public  void TogglePauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause)
        {
            Time.timeScale = 0f;
            OnPauseAction?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void tinmeScaleOn()
    {
        Time.timeScale = 0f;
    }

    public void tinmeScaleOff()
    {
        Time.timeScale = 1f;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public float GetGamePlayingTimerNormaliezed()
    {
        return 1 - (gamePLayingTimer / gamePLayingTimerMax);
    }

    private float getGamePlayingTimerMax()
    {
        LevelButtonManager levelButtonManager = LevelButtonManager.Instance;
        int gameLevel = (int)levelButtonManager.gameLevel;


        if (gameLevel == 0)
        {
            gamePLayingTimerMax = easyLevelMaxTime;
        }
        else if (gameLevel == 1)
        {
            gamePLayingTimerMax = mediumLevelMaxTime;
        }
        else if (gameLevel == 2)
        {
            gamePLayingTimerMax = hardLevelMaxTime;
        }
        return gamePLayingTimerMax;
    }

    public void RaiseChangeWinEvent()
    {
        OnWinChanged?.Invoke(this, EventArgs.Empty);
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int score)
    {
        this.score = score;
    }
}
