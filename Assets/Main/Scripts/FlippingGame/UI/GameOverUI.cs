using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    private bool isGameVictoryShown = false;

    [SerializeField]
    private TextMeshProUGUI resultText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        MiniGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
        Hide();
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MiniGameManager.Instance.IsGameOver() && Flip_GameController.Instance.CheckIfTheGameIsFinished() == false && !isGameVictoryShown)
        {
            Show();
            //resultText.text = Flip_GameController.Instance.GetCountCorrectGuesses().ToString();
            resultText.text = MiniGameManager.Instance.GetScore().ToString();
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

    public void SetGameVictoryShown(bool value)
    {
        isGameVictoryShown = value;
    }
}
