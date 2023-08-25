using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip_GameController : MonoBehaviour
{
    public List<Button> cardButtons;

    public Sprite[] icon;

    public List<Sprite> cardIcon;

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzel, secondGuessPuzzel;


    private void Awake()
    {
        cardButtons = new List<Button>();
        cardIcon = new List<Sprite>();
        icon = Resources.LoadAll<Sprite>("Sprites/icon");
    }

    private void Start()
    {
        GetCardButtons();
        AddListeners();
        AddCardIcon();
    }

    void GetCardButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardButton");

        for (int i = 0; i < objects.Length; i++)
        {
            cardButtons.Add(objects[i].GetComponent<Button>());
        }
    }

    void AddCardIcon()
    {
        int looper = cardButtons.Count;
        int index = 0;

        for(int i = 0;i < looper;i++)
        {
            if(index ==  looper/2)
            {
                index = 0;
            }

            cardIcon.Add(icon[index]);
            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button button in cardButtons)
        {
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzel = cardIcon[firstGuessIndex].name;

            Image image = cardButtons[firstGuessIndex].transform.Find("Image").GetComponent<Image>();

            // Kiểm tra xem các gameobject con có tồn tại hay không
            if (image != null)
            {
                // Thiết lập hiển thị cho Image
                image.gameObject.SetActive(true);
                image.sprite = cardIcon[firstGuessIndex];
            }
        }
        else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzel = cardIcon[secondGuessIndex].name;

            Image image = cardButtons[secondGuessIndex].transform.Find("Image").GetComponent<Image>();

            // Kiểm tra xem các gameobject con có tồn tại hay không
            if (image != null)
            {
                // Thiết lập hiển thị cho Image
                image.gameObject.SetActive(true);
                image.sprite = cardIcon[secondGuessIndex];
            }

            if (firstGuessPuzzel == secondGuessPuzzel)
            {
                Debug.Log("Match");
            } else
            {
                Debug.Log("Don't Match");
            }
        }
    }
}
