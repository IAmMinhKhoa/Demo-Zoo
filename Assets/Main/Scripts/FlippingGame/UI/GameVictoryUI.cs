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
        Flip_GameController.Instance.OnStateChanged += FlipGameController_OnStateChanged;
        Hide();
    }

    private void FlipGameController_OnStateChanged(object sender, System.EventArgs e)
    {
        Show();   
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
