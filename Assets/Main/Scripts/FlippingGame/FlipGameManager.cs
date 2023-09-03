using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGameManager : MonoBehaviour
{
    public static FlipGameManager Instance { get; private set;  }

    public event EventHandler OnStateChanged;

    public event EventHandler OnGetCard;


    public event EventHandler OnPauseAction;
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    [SerializeField] private float easyLevelMaxTime = 5f;
    [SerializeField] private float mediumLevelMaxTime = 30f;
    [SerializeField] private float hardLevelMaxTime = 40f;

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePLayingTimer;
    private float gamePLayingTimerMax;
    private bool isGamePause = false;



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
                    OnGetCard?.Invoke(this, EventArgs.Empty);
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
        //Debug.Log(isGamePause);

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

    public void TogglePauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause)
        {
            Time.timeScale = 0f;
            OnPauseAction?.Invoke(this, EventArgs.Empty);
        } else
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
}
