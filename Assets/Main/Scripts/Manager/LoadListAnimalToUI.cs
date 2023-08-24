using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static SO_ListAnimal;

public class LoadListAnimalToUI : MonoBehaviour
{
    public GameObject prefabCardAnimal;
    public enum NameZone { 
        Forest,
        Winter,
        cc
    }
    [SerializeField] NameZone nameZone;
    
    protected List<string> ListNameZone = new List<string>();
  
    public SO_ListAnimal listAnimal;

    private void Awake()
    {
        foreach (AnimalZone animal in listAnimal.List_Animal_Zone)
        {
            ListNameZone.Add(animal.NameZone);
        }

    }
    private void Start()
    {
        string zone=nameZone.ToString();
        LoadData(zone);
       
    }
    protected void LoadDataListNameZone()
    {
        foreach (AnimalZone animalZone in listAnimal.List_Animal_Zone)
        {
            ListNameZone.Add(animalZone.NameZone);

        }
    }


    protected void LoadData(String name)
    {
        bool checkFindZone=false;
        GameObject GO_ListAnimal = FindChildObject(this.gameObject, "List Animal");
        
        foreach (AnimalZone ListZone in listAnimal.List_Animal_Zone)
        {
            if(ListZone.NameZone == name)
            {
                foreach  (SO_Animal ListDataAnimal in ListZone.DATA_Animals)
                {
                    checkFindZone = true;
                    ComponentCardAnimalInBook componentCardAnimalInBook = prefabCardAnimal.GetComponent<ComponentCardAnimalInBook>();
                    componentCardAnimalInBook.LoadDataToCard(ListDataAnimal);
                    componentCardAnimalInBook.InstanceCardAnimal(GO_ListAnimal);
                }
            }
        }
        if (checkFindZone != true)
        {
            Debug.LogWarning("Not Finding this " + name+" Zone");
        }
    }

 

    protected GameObject FindChildObject(GameObject parent,string name)
    {
        Transform childObject = parent.transform.Find(name);
        if (childObject != null)
        {
            return childObject.gameObject;
        }
        else
        {
            return null;
        }
    }
}
