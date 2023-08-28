using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Button button;
    private Image rend;

    [SerializeField]
    private Sprite backSprite;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        rend = button.GetComponent<Image>();
        rend.sprite = backSprite;
    }
}
