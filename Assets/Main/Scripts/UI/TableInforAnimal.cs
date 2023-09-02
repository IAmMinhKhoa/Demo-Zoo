using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class TableInforAnimal : MonoBehaviour
{
    

    public TextMeshProUGUI text_SubBottom;
    public Image img_demo;

    public TextMeshProUGUI text_Name;
    public GameObject GO_Speaker_Name;
    public GameObject GO_Speaker_food;
    public GameObject GO_Speaker_characteristic;
    public GameObject GO_Speaker_conservation;
    public GameObject GO_Speaker_habitat;
    

    public AudioSource GetAudioSourceInTable(GameObject GO)
    {
        AudioSource Source = GO.GetComponent<AudioSource>();
        return Source;
    }

    public void LoadAudio(GameObject GO,AudioClip source)
    {
        GetAudioSourceInTable(GO).clip = source;
    }

    public Button GetButtonInTable(GameObject GO)
    {
        Button Button = GO.GetComponent<Button>();
        return Button;
    }
    public void SetUpEventButton(GameObject GO, UnityAction action)
    {
        GetButtonInTable(GO).onClick.AddListener(action);
    }
    public void PlayAudio(GameObject GO)
    {
        StopAllSound();
        GetAudioSourceInTable(GO).Play();
    }
    public void SetTextBottom(string text)
    {
        text_SubBottom.text = text; 
    }
    protected void StopAllSound()
    {
        GetAudioSourceInTable(GO_Speaker_Name).Stop();
        GetAudioSourceInTable(GO_Speaker_food).Stop();
        GetAudioSourceInTable(GO_Speaker_characteristic).Stop();
        GetAudioSourceInTable(GO_Speaker_conservation).Stop();
        GetAudioSourceInTable(GO_Speaker_habitat).Stop();
    }
}
