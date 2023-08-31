using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDatatoTableInforAnimal : MonoBehaviour
{
    [SerializeField] SO_Animal SOanimal;
    [SerializeField] TableInforAnimal tableInforAnimal;
    protected string nameAnimal;
        
    private void Start()
    {
        nameAnimal = SOanimal.Str_NameVn + " - " + SOanimal.Str_NameUs;
        LoadData();
        tableInforAnimal.GO_Speaker_food.GetComponent<Button>().onClick.AddListener(food);
    }
    protected void LoadData()
    {
        tableInforAnimal.text_Name.text=nameAnimal;
        


        tableInforAnimal.GO_Speaker_food.GetComponent<AudioSource>().clip = SOanimal.IC_Food.A_audio;
    }
    protected void food()
    {
        tableInforAnimal.text_SubBottom.text = SOanimal.IC_Food.Str_Content;
    }

  
}
