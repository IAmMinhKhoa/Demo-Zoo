using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject Button;

    //private void Awake()
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        GameObject cardButton = Instantiate(Button);
    //        cardButton.name ="" + i;
    //        cardButton.transform.SetParent(puzzleField, false);
    //    }    
    //}

    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsGamePlaying())
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject cardButton = Instantiate(Button);
                cardButton.name = "" + i;
                cardButton.transform.SetParent(puzzleField, false);
            }
        }
    }
}
