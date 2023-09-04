using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static LevelManager;

public class LevelButtonManager : MonoBehaviour
{
    public static LevelButtonManager Instance { get; private set; }

    [SerializeField] private GameObject LevelUI;
    [SerializeField] private GameObject GanmeContent;


    public enum GameLevel
    {
        Easy,
        Medium,
        Hard
    }

    public GameLevel gameLevel;

    private void Awake()
    {
        Instance = this;
    }

     public void easyButton()
     {
        if(LevelManager.Instance.isEasyUnlocked)
        {
            gameLevel = GameLevel.Easy;
            LevelUI.SetActive(false);
            GanmeContent.SetActive(true);
        }
     }

    public void mediumButton()
    {
        if (LevelManager.Instance.isMediumUnlocked)
        {
            gameLevel = GameLevel.Medium;
            LevelUI.SetActive(false);
            GanmeContent.SetActive(true);

        }
    }

    public void hardButton()
    {
        if (LevelManager.Instance.isHardUnlocked)
        {
            gameLevel = GameLevel.Hard;
            LevelUI.SetActive(false);
            GanmeContent.SetActive(true);

        }
    }

    public void closeButton() 
    {
        SceneManager.LoadScene("MenuMiniGame");
    }
}

