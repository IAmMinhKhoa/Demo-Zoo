using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDatatoTableInforAnimal : MonoBehaviour
{
    [SerializeField] SO_Animal SO_animal;
    [SerializeField] TableInforAnimal tableInforAnimal;
        
    private void Start()
    {
        LoadDataSound();
        LoadDataText();
        LoadEventButton();
    }

    protected void LoadDataSound() {
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_Name, SO_animal.IC_Name.A_audio);
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_habitat, SO_animal.IC_Habitat.A_audio);
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_food, SO_animal.IC_Food.A_audio);
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_conservation, SO_animal.IC_Conservation.A_audio);
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_characteristic, SO_animal.IC_Characteristic.A_audio);
    }
    
    protected void LoadDataText()
    {
        string nameAnimal = SO_animal.Str_NameVn + " - " + SO_animal.Str_NameUs;
        tableInforAnimal.text_Name.text = nameAnimal;
    }


    protected void LoadEventButton()
    {
        tableInforAnimal.SetUpEventButton(tableInforAnimal.GO_Speaker_Name, EventButtonName);
        tableInforAnimal.SetUpEventButton(tableInforAnimal.GO_Speaker_habitat, EvenButtonHabita);
        tableInforAnimal.SetUpEventButton(tableInforAnimal.GO_Speaker_food, EvenButtonFood);
        tableInforAnimal.SetUpEventButton(tableInforAnimal.GO_Speaker_conservation, EvenButtonConservation);
        tableInforAnimal.SetUpEventButton(tableInforAnimal.GO_Speaker_characteristic, EvenButtonCharacteristic);
    }



    //event each Button
    protected void EventButtonName()
    {
        tableInforAnimal.SetActiveBottom(true);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_Name);
        tableInforAnimal.SetTextBottom(SO_animal.IC_Name.Str_Content);

        LoadImageFromSO_Animal(SO_animal.IC_Name);
    }
    protected void EvenButtonHabita()
    {
        tableInforAnimal.SetActiveBottom(true);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_habitat);
        tableInforAnimal.SetTextBottom(SO_animal.IC_Habitat.Str_Content);

        LoadImageFromSO_Animal(SO_animal.IC_Habitat);
    }
    protected void EvenButtonFood()
    {
        tableInforAnimal.SetActiveBottom(true);
        tableInforAnimal.SetTextBottom(SO_animal.IC_Food.Str_Content);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_food);
         LoadImageFromSO_Animal(SO_animal.IC_Food);

    }
    protected void EvenButtonConservation()
    {
        tableInforAnimal.SetActiveBottom(true);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_conservation);
        tableInforAnimal.SetTextBottom(SO_animal.IC_Conservation.Str_Content);

        LoadImageFromSO_Animal(SO_animal.IC_Conservation);
    }
    protected void EvenButtonCharacteristic()
    {
        tableInforAnimal.SetActiveBottom(true);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_characteristic);
        tableInforAnimal.SetTextBottom(SO_animal.IC_Characteristic.Str_Content);

        LoadImageFromSO_Animal(SO_animal.IC_Characteristic);
    }

    protected void LoadImageFromSO_Animal(InformationCluster IC)
    {
        tableInforAnimal.InitListImage(IC.L_Sprite);

    }


}
