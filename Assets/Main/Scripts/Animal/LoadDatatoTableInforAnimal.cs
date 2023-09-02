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
        tableInforAnimal.LoadAudio(tableInforAnimal.GO_Speaker_Name, SO_animal.A_NameVnUs);
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
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_Name);
    }
    protected void EvenButtonHabita()
    {
       
    }
    protected void EvenButtonFood()
    {
        tableInforAnimal.SetTextBottom(SO_animal.IC_Food.Str_Content);
        tableInforAnimal.PlayAudio(tableInforAnimal.GO_Speaker_food);
    }
    protected void EvenButtonConservation()
    {

    }
    protected void EvenButtonCharacteristic()
    {

    }



}
