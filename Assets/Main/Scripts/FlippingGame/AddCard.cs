using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCard : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject Button;

    private void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject cardButton = Instantiate(Button);
            cardButton.name = "Card " + i;
            cardButton.transform.SetParent(puzzleField, false);
        }    
    }
}
