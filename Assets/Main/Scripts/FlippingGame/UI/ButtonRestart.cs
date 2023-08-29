using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    private Button restartButton;

    private void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
