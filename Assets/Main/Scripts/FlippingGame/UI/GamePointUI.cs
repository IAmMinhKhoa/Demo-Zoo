using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePointUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointText;

    private void Update()
    {
        pointText.text = Flip_GameController.Instance.GetCountCorrectGuesses().ToString();
    }
}
