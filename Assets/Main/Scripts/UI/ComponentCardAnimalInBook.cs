using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ComponentCardAnimalInBook : MonoBehaviour
{
    
    public Image Icon;
    public TextMeshProUGUI TextNameVN;
    public TextMeshProUGUI TextNameUS;

    public GameObject GO_Speaker_NameVn;
    public GameObject GO_Speaker_NameUs;


    public void LoadDataToCard(SO_Animal ListDataAnimal)
    {
        Icon.sprite = ListDataAnimal.Icon;
        TextNameVN.text = ListDataAnimal.Str_NameVn;
        TextNameUS.text = ListDataAnimal.Str_NameUs;
        GetAudioSourceInTable(GO_Speaker_NameVn).clip = ListDataAnimal.A_NameVn;
        GetAudioSourceInTable(GO_Speaker_NameUs).clip = ListDataAnimal.A_NameUs;
        
    }
    
    public void InstanceCardAnimal(GameObject GO_ListAnimal)
    {
        GameObject CardAnimal = Instantiate(this.gameObject);
        CardAnimal.transform.SetParent(GO_ListAnimal.transform);
        CardAnimal.transform.localScale = new Vector3(1, 1, 1);
        LoadEventToButton();
    }
    protected void LoadEventToButton()
    {
        GetButtonInTable(GO_Speaker_NameVn).onClick.AddListener(EventButonSpeaker_NameVn);
        GetButtonInTable(GO_Speaker_NameUs).onClick.AddListener(EventButonSpeaker_NameUs);
        
    }
    protected AudioSource GetAudioSourceInTable(GameObject GO)
    {
        AudioSource Source = GO.GetComponent<AudioSource>();
        return Source;
    }
    protected Button GetButtonInTable(GameObject GO)
    {
        Button Button = GO.GetComponent<Button>();
        return Button;
    }
    protected void StopAllSound()
    {
        GetAudioSourceInTable(GO_Speaker_NameVn).Stop();
        GetAudioSourceInTable(GO_Speaker_NameUs).Stop();
       
    }
    //EVENT EACH BUTTON
    protected void EventButonSpeaker_NameVn()
    {
        StopAllSound();
        GetAudioSourceInTable(GO_Speaker_NameVn).Play();
        Debug.Log("cc?");
    }
    protected void EventButonSpeaker_NameUs()
    {
        StopAllSound();
        GetAudioSourceInTable(GO_Speaker_NameUs).Play();
    }
}

