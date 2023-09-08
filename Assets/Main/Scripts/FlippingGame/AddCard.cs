using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public static AddCard Instance { get; private set; }


    public List<Button> cardButtons;
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject Button;

    [SerializeField]
    private int numberCardEasy;
    [SerializeField]
    private int numberCardMedium;
    [SerializeField]
    private int numberCardHard;

    private void Awake()
    {
        Instance = this;
        cardButtons = new List<Button>();
    }

    private void Start()
    {
        MiniGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MiniGameManager.Instance.IsGamePlaying())
        {
            LevelButtonManager levelButtonManager = LevelButtonManager.Instance;
            int gameLevel = (int)levelButtonManager.gameLevel;
            
            if (gameLevel == 0)
            {
                // Mở khóa level Easy
                for (int i = 0; i < numberCardEasy; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                    cardButtons.Add(cardButton.GetComponent<Button>());
                }
            }
            else if (gameLevel == 1)
            {
                // Mở khóa level Medium
                for (int i = 0; i < numberCardMedium; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                    cardButtons.Add(cardButton.GetComponent<Button>());
                }
            }
            else if (gameLevel == 2)
            {
                // Mở khóa level Hard
                for (int i = 0; i < numberCardHard; i++)
                {
                    GameObject cardButton = Instantiate(Button);
                    cardButton.name = "" + i;
                    cardButton.transform.SetParent(puzzleField, false);
                    cardButtons.Add(cardButton.GetComponent<Button>());
                }
            }
        }
    }

    public void DestroyCardButtons()
    {
        foreach (Button cardButton in cardButtons)
        {
            Destroy(cardButton.gameObject);
        }

        cardButtons.Clear();
    }
}
