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

    public void ChangeIcon(Sprite image)
    {
        Icon.sprite = image;
    }
    public void ChangeName(string nameVN, string nameUS)
    {
        TextNameVN.text = nameVN;
        TextNameUS.text = nameUS;
    }

    public void InstanceCardAnimal(GameObject GO_ListAnimal, SO_Animal ListDataAnimal)
    {
        GameObject CardAnimal = Instantiate(this.gameObject);
        CardAnimal.transform.SetParent(GO_ListAnimal.transform);
        CardAnimal.transform.localScale = new Vector3(1, 1, 1);
        ChangeIcon(ListDataAnimal.Icon);
        ChangeName(ListDataAnimal.NameVn, ListDataAnimal.NameUS);
    }
}
