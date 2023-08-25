using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip_GameController : MonoBehaviour
{
    public List<Button> cardButtons;

    private void Awake()
    {
        cardButtons = new List<Button>();
    }

    private void Start()
    {
        GetCardButtons();
    }

    void GetCardButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardButton");

        for (int i = 0; i < objects.Length; i++)
        {
            cardButtons.Add(objects[i].GetComponent<Button>());
        }
    }
}
