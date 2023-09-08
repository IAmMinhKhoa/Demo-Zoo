using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MonoBehaviour
{
    public static GamePauseUI Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        MiniGameManager.Instance.OnPauseAction += FlipGameManager_OnPauseAction;
        Hide();
    }

    private void FlipGameManager_OnPauseAction(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
