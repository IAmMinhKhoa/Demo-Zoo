using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownText;

    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsCountdownToStartActive())
        {
            Show();   
        } else
        {
            Hide();
        }    
    }

    private void Update()
    {
        countdownText.text = Mathf.Ceil(FlipGameManager.Instance.GetCountdownToStartTimer()).ToString();
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
