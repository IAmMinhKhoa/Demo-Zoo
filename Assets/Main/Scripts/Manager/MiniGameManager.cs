using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    protected enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    protected State state;
    protected float waitingToStartTimer = 1f;
    protected float countdownToStartTimer = 3f;
    protected float gamePLayingTimer;
    protected float gamePLayingTimerMax;
    protected bool isGamePause = false;

    //private void Awake()
    //{
    //    Instance = this;

    //    // Khởi tạo các giá trị khác   
    //    state = State.WaitingToStart;
    //}

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

    public virtual void restartGame()
    {
        waitingToStartTimer = 1f;
        countdownToStartTimer = 3f;
        gamePLayingTimer = 0f;
        isGamePause = false;
        state = State.WaitingToStart;
    }

    public virtual void TogglePauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause)
        {
            Time.timeScale = 0f;
            //OnPauseAction?.Invoke(this, EventArgs.Empty);
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

}
