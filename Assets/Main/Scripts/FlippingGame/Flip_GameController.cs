using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip_GameController : MonoBehaviour
{
    public static Flip_GameController Instance { get; private set; }

    public event EventHandler OnStateChanged;

    [SerializeField]
    private Sprite frontSprite, backSprite;

    public List<Button> cardButtons;

    public Sprite[] icon;

    public List<Sprite> cardIcon;         

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses = 0;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzel, secondGuessPuzzel;



    private void Awake()
    {
        Instance = this;
        cardButtons = new List<Button>();
        cardIcon = new List<Sprite>();
        icon = Resources.LoadAll<Sprite>("Sprites/icon");
    }

    //private void Start()
    //{
    //    GetCardButtons();
    //    AddListeners();
    //    AddCardIcon();
    //    Shuffle(cardIcon);
    //    gameGuesses = cardIcon.Count / 2;
    //}

    private void Start()
    {
        FlipGameManager.Instance.OnStateChanged += FlipGameManager_OnStateChanged;
    }

    private void Update()
    {
         
    }

    private void FlipGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (FlipGameManager.Instance.IsGamePlaying())
        {
            GetCardButtons();
            AddListeners();
            AddCardIcon();
            Shuffle(cardIcon);
            gameGuesses = cardIcon.Count / 2;
        }
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
        if (!FlipGameManager.Instance.IsGamePlaying()) return;
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzel = cardIcon[firstGuessIndex].name;

            FlipFrontCard(cardButtons[firstGuessIndex]);

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

            FlipFrontCard(cardButtons[secondGuessIndex]);

            Image image = cardButtons[secondGuessIndex].transform.Find("Image").GetComponent<Image>();

            // Kiểm tra xem các gameobject con có tồn tại hay không
            if (image != null)
            {
                // Thiết lập hiển thị cho Image
                image.gameObject.SetActive(true);
                image.sprite = cardIcon[secondGuessIndex];
            }

            countGuesses++;

            StartCoroutine(CheckIfTheCardMatch());

        }
    }

    IEnumerator CheckIfTheCardMatch()
    {
        //yield return new WaitForSeconds(1f);

        if(firstGuessPuzzel == secondGuessPuzzel)
        {
            yield return new WaitForSeconds(.5f);

            cardButtons[firstGuessIndex].interactable = false;
            cardButtons[secondGuessIndex].interactable = false;

            cardButtons[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            cardButtons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            Image firstImage = cardButtons[firstGuessIndex].transform.Find("Image").GetComponent<Image>();
            Image secondImage = cardButtons[secondGuessIndex].transform.Find("Image").GetComponent<Image>();

            // Kiểm tra xem các gameobject con có tồn tại hay không
            if (firstImage != null && secondImage != null)
            {
                // Thiết lập hiển thị cho Image
                firstImage.gameObject.SetActive(false);
                secondImage.gameObject.SetActive(false);
            }

            countCorrectGuesses++;
            if (CheckIfTheGameIsFinished() == true)
            {
                OnStateChanged?.Invoke(this, EventArgs.Empty);
            }
        }  
        else
        {
            yield return new WaitForSeconds(1f);

            FlipBackCard(cardButtons[firstGuessIndex]);
            FlipBackCard(cardButtons[secondGuessIndex]);

            cardButtons[firstGuessIndex].interactable = true;
            cardButtons[secondGuessIndex].interactable = true;

            Image firstImage = cardButtons[firstGuessIndex].transform.Find("Image").GetComponent<Image>();
            Image secondImage = cardButtons[secondGuessIndex].transform.Find("Image").GetComponent<Image>();

            // Kiểm tra xem các gameobject con có tồn tại hay không
            if (firstImage != null && secondImage != null)
            {
                // Thiết lập hiển thị cho Image
                firstImage.gameObject.SetActive(false);
                secondImage.gameObject.SetActive(false);
            }
        }
        //yield return new WaitForSeconds(1f);

        firstGuess = secondGuess = false;
    }

    public bool CheckIfTheGameIsFinished()
    {
        if (gameGuesses > 0)
        {
            return countCorrectGuesses == gameGuesses;
        }
        else
            return false;
    }

    private void FlipFrontCard(Button button)
    {
        StartCoroutine(RotateFront(button));
    }

    private void FlipBackCard(Button button)
    {
        StartCoroutine(RotateBack(button));
    }

    private IEnumerator RotateFront(Button button)
    {
        if (button.image.sprite == backSprite)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                button.transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    button.image.sprite = frontSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RotateBack(Button button)
    {
        if (button.image.sprite == frontSprite)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                button.transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    button.image.sprite = backSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    private void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite sprite = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = sprite;
        }
    }

    public int GetCountCorrectGuesses()
    {
        return countCorrectGuesses;
    }
}
