using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    private Button restartButton;

    [SerializeField] private GameObject panelParent;

    private void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void OnRestartButtonClicked()
    {
        Hide();
        FlipGameManager.Instance.restartGame();
        Flip_GameController.Instance.ResetArrays();
    }

    private void Show()
    {
        panelParent.SetActive(true);
    }

    private void Hide()
    {
        panelParent.SetActive(false);
    }
}
