using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public bool isEasyUnlocked { get; private set; }
    public bool isMediumUnlocked { get; private set; }
    public bool isHardUnlocked { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockEasyLevel()
    {
        isEasyUnlocked = true;
    }

    public void UnlockMediumLevel()
    {
        isMediumUnlocked = true;
    }

    public void UnlockHardLevel()
    {
        isHardUnlocked = true;
    }
}
