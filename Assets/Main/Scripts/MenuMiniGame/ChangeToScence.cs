using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToScence : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneFlippingGame;

    public void OnButtonClickToFlippingGame()
    {
        SceneManager.LoadScene(sceneFlippingGame.name);
    }
}
