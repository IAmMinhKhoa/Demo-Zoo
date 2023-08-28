using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzelFieldUI : MonoBehaviour
{
    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
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
