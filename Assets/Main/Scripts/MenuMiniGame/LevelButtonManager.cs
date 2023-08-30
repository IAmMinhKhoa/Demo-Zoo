using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public void UnlockEasyLevel()
    {
        LevelManager.Instance.UnlockEasyLevel();
        SceneManager.LoadScene("FlippingGame");
    }

    public void UnlockMediumLevel()
    {
        LevelManager.Instance.UnlockMediumLevel();
        SceneManager.LoadScene("FlippingGame");
    }

    public void UnlockHardLevel()
    {
        LevelManager.Instance.UnlockHardLevel();
        SceneManager.LoadScene("FlippingGame");
    }
}
