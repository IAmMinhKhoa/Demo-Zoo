using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentCardAnimalInBook : MonoBehaviour
{
    
    public Image Icon;
    public TextMeshProUGUI TextNameVN;
    public TextMeshProUGUI TextNameUS;

    public AudioSource AudioSoundVN;
    public AudioSource AudioSoundUS;

   
    public void LoadDataToCard(SO_Animal ListDataAnimal)
    {
        Icon.sprite = ListDataAnimal.Icon;
        TextNameVN.text = ListDataAnimal.NameVn;
        TextNameUS.text = ListDataAnimal.NameUS;
        AudioSoundVN.clip = ListDataAnimal.animalSound;
        AudioSoundUS.clip = ListDataAnimal.animalSound;
    }
    public void InstanceCardAnimal(GameObject GO_ListAnimal)
    {
        GameObject CardAnimal = Instantiate(this.gameObject);
        CardAnimal.transform.SetParent(GO_ListAnimal.transform);
        CardAnimal.transform.localScale = new Vector3(1, 1, 1);
   
    }
}
