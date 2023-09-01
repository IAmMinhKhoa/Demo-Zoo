using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public enum GameLevelManager
    {
        Easy,
        Medium,
        Hard
    }

    public GameLevelManager currentLevel;  //level đạt được

    public bool isEasyUnlocked { get; private set; }
    public bool isMediumUnlocked { get; private set; }
    public bool isHardUnlocked { get; private set; }

    private bool isFirstRun;

    private void Awake()
    {
        Instance = this;
        isFirstRun = PlayerPrefs.GetInt("IsFirstRun", 1) == 1;

        if (isFirstRun)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("IsFirstRun", 0);
        }
    }

    private void Start()
    {
        LoadSavedLevel();
        LoadUnlockedLevels();
        isEasyUnlocked = true; 
    }

    private void Update()
    {
        Debug.Log(currentLevel + " " + isMediumUnlocked);
    }

    public void UnlockLevel(GameLevelManager level)
    {
        currentLevel = level;
        // Gọi phương thức UnlockLevel tương ứng
        switch (level)
        {
            case GameLevelManager.Easy:
                isEasyUnlocked = true;
                break;
            case GameLevelManager.Medium:
                isMediumUnlocked = true;
                break;
            case GameLevelManager.Hard:
                isHardUnlocked = true;
                break;
        }
        Debug.Log(currentLevel.ToString() + " " + isMediumUnlocked);
        SaveLevel();
        SaveUnlockedLevels();
    }

    public void OnGameVictory()     //chiến thắng sẽ unlock level tiếp theo
    {
        switch (currentLevel)
        {
            case GameLevelManager.Easy:
                UnlockLevel(GameLevelManager.Medium);
                Debug.Log("Đã mở khóa Medium");
                break;
            case GameLevelManager.Medium:
                UnlockLevel(GameLevelManager.Hard);
                Debug.Log("Đã mở khóa Hard");
                break;
            case GameLevelManager.Hard:
                // Đã đạt cấp độ cao nhất, không có cấp độ tiếp theo để mở khóa
                break;
        }
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", currentLevel.ToString());
        PlayerPrefs.Save();
        Debug.Log("Đã save Level");
    }

    private void SaveUnlockedLevels()
    {
        PlayerPrefs.SetInt("IsEasyUnlocked", isEasyUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("IsMediumUnlocked", isMediumUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("IsHardUnlocked", isHardUnlocked ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Đã save Unlocked Levels");
    }

    public void LoadSavedLevel()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            string savedLevel = PlayerPrefs.GetString("CurrentLevel");
            currentLevel = (GameLevelManager)System.Enum.Parse(typeof(GameLevelManager), savedLevel);
            Debug.Log("level mới: " + currentLevel.ToString());
        }
        else
        {
            currentLevel = GameLevelManager.Easy;
        }
    }

    public void LoadUnlockedLevels()
    {
        if (PlayerPrefs.HasKey("IsEasyUnlocked"))
        {
            isEasyUnlocked = PlayerPrefs.GetInt("IsEasyUnlocked") == 1;
        }
        else
        {
            isEasyUnlocked = true; // Hoặc giá trị mặc định khác tùy theo logic của bạn
        }

        if (PlayerPrefs.HasKey("IsMediumUnlocked"))
        {
            isMediumUnlocked = PlayerPrefs.GetInt("IsMediumUnlocked") == 1;
        }
        else
        {
            isMediumUnlocked = false; // Hoặc giá trị mặc định khác tùy theo logic của bạn
        }

        if (PlayerPrefs.HasKey("IsHardUnlocked"))
        {
            isHardUnlocked = PlayerPrefs.GetInt("IsHardUnlocked") == 1;
        }
        else
        {
            isHardUnlocked = false; // Hoặc giá trị mặc định khác tùy theo logic của bạn
        }

    }
}
