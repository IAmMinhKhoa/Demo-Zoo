using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePointUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointText;

    private void Start()
    {
        Hide();
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void Update()
    {
        pointText.text = Flip_GameController.Instance.GetCountCorrectGuesses().ToString();
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsGamePlaying())
        {
            Show();
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
