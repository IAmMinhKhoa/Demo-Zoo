using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVictoryUI : MonoBehaviour
{
    public static GameVictoryUI Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // Flip_GameController.Instance.OnWinChanged += FlipGameController_OnWinChanged;
        MiniGameManager.Instance.OnWinChanged += Instance_OnWinChanged;
        Hide();
    }

    private void Instance_OnWinChanged(object sender, System.EventArgs e)
    {
        Show();
        GameOverUI.Instance.SetGameVictoryShown(true);
    }

    

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
