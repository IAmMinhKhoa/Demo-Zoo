using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public static LevelButtonManager Instance { get; private set; }

    public bool isEasyLevel { get; private set; }
    public bool isMediumLevel { get; private set; }
    public bool isHardLevel { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockEasyLevel()
    {
        if (!isEasyLevel)
        {
            isEasyLevel = true;     
            isMediumLevel = false;
            isHardLevel = false;
        }
        LevelManager.Instance.UnlockEasyLevel();
        SceneManager.LoadScene("FlippingGame");

    }

    public void UnlockMediumLevel()
    {
        if (!isMediumLevel)
        {
            isMediumLevel = true;
            isEasyLevel = false;
            isHardLevel = false;
        }
        LevelManager.Instance.UnlockMediumLevel();
        SceneManager.LoadScene("FlippingGame");

    }

    public void UnlockHardLevel()
    {
        if (!isHardLevel)
        {
            isHardLevel = true;
            isEasyLevel = false;
            isMediumLevel = false;
        }
        LevelManager.Instance.UnlockHardLevel();
        SceneManager.LoadScene("FlippingGame");
    }
}

