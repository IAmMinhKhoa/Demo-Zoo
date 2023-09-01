using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static LevelManager;

public class LevelButtonManager : MonoBehaviour
{
    public static LevelButtonManager Instance { get; private set; }

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
            SceneManager.LoadScene("FlippingGame");
        }
     }

    public void mediumButton()
    {
        if (LevelManager.Instance.isMediumUnlocked)
        {
            gameLevel = GameLevel.Medium;
            SceneManager.LoadScene("FlippingGame");
        }
    }

    public void hardButton()
    {
        if (LevelManager.Instance.isHardUnlocked)
        {
            gameLevel = GameLevel.Hard;
            SceneManager.LoadScene("FlippingGame");
        }
    }
}

