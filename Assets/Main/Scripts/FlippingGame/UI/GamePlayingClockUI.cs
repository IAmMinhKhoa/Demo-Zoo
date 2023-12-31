using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;

    private void Start()
    {
        Hide();
        MiniGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void Update()
    {
        timerImage.fillAmount = MiniGameManager.Instance.GetGamePlayingTimerNormaliezed();
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MiniGameManager.Instance.IsGamePlaying())
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
