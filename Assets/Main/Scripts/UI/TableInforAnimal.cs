using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class TableInforAnimal : MonoBehaviour
{
    

    public TextMeshProUGUI text_SubBottom;
    public GameObject GO_ScrollImage;


    public TextMeshProUGUI text_Name;
    public GameObject GO_Speaker_Name;
    public GameObject GO_Speaker_food;
    public GameObject GO_Speaker_characteristic;
    public GameObject GO_Speaker_conservation;
    public GameObject GO_Speaker_habitat;

    private void Start()
    {
        SetActiveBottom(false);
    }

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

    public void SetActiveBottom(bool check)
    {
        text_SubBottom.transform.parent.parent.gameObject.SetActive(check);
        GO_ScrollImage.SetActive(check);
    }

    public void InitListImage(List<Sprite> L_Image)
    {
        GameObject GO_ContentScroll = GO_ScrollImage.transform.GetChild(0).GetChild(0).gameObject;
        GameObject prefab_image = GO_ContentScroll.transform.GetChild(0).gameObject;


        if (L_Image.Count != 0)
        {
            //reset trong content(ch?a l?i 1 ?nh)
            DestroyChildren(GO_ContentScroll);


            //instance theo sl anh
            for (int i = 0; i < L_Image.Count; i++)
            {
                GameObject GO_image = Instantiate(prefab_image, GO_ContentScroll.transform);
                Image image = GO_image.GetComponent<Image>();
                image.sprite = L_Image[i];
                image.enabled = true;
            }
        }
        else
        {
            GO_ScrollImage.SetActive(false);
        }
    }
    private void DestroyChildren(GameObject parent)
    {
        // L?p qua t?t c? các ??i t??ng con trong ??i t??ng cha
        foreach (Transform child in parent.transform)
        {
            // Xóa ??i t??ng con
            Destroy(child.gameObject);
            // Ho?c s? d?ng DestroyImmediate(child.gameObject) n?u b?n mu?n xóa ngay l?p t?c mà không ch? khung c?p nh?t ti?p theo
        }
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
