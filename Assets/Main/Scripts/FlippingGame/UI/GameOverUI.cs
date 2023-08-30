using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI resultText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
        Hide();
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsGameOver() && Flip_GameController.Instance.CheckIfTheGameIsFinished() == false)
        {
            Show();
            resultText.text = Flip_GameController.Instance.GetCountCorrectGuesses().ToString();
        }
        else
        {
            Hide();
        }
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
