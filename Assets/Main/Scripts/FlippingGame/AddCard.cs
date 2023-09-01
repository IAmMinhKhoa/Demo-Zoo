using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject Button;

    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsGamePlaying())
        {
            LevelManager levelManager = LevelManager.Instance;
            bool isEasyUnlocked = levelManager.isEasyUnlocked;
            bool isMediumUnlocked = levelManager.isMediumUnlocked;
            bool isHardUnlocked = levelManager.isHardUnlocked;

            if (isEasyUnlocked)
            {
                // Mở khóa level Easy
                for (int i = 0; i < 8; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                }
            }
            else if (isMediumUnlocked)
            {
                // Mở khóa level Medium
                for (int i = 0; i < 10; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                }
            }
            else if (isHardUnlocked)
            {
                // Mở khóa level Hard
                for (int i = 0; i < 14; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                }
            }
        }
    }
}
