using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TableInforAnimal : MonoBehaviour
{
    

    public TextMeshProUGUI text_SubBottom;
    public Image img_demo;

    public TextMeshProUGUI text_Name;
    public GameObject GO_Speaker_Name;
    public GameObject GO_Speaker_food;
    public GameObject GO_Speaker_characteristic;
    public GameObject GO_Speaker_conservatio;
    public GameObject GO_Speaker_habitat;
    

    public AudioSource GetAudioSourceInTable(GameObject GO)
    {
        AudioSource Source = GO.GetComponent<AudioSource>();
        return Source;
    }

    public Button GetButtonInTable(GameObject GO)
    {
        Button Button = GO.GetComponent<Button>();
        return Button;
    }
}
