using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static SO_ListAnimal;

public class LoadListAnimalToUI : MonoBehaviour
{


 



    public enum NameZone { Forest }
    [SerializeField] NameZone nameZone;
    protected List<string> ListNameZone = new List<string>();
    public GameObject prefabCardAnimal;
    public SO_ListAnimal listAnimal;
 

    private void Start()
    {
        LoadData("Forest");
        //LoadDataListNameZone();

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
                checkFindZone = true;
                foreach  (SO_Animal ListDataAnimal in ListZone.DATA_Animals)
                {
                    InstanceCardAnimal(GO_ListAnimal,ListDataAnimal);
                }
            }
        }
        if (checkFindZone != true)
        {
            Debug.LogWarning("Not Finding this " + name);
        }
    }

    protected void InstanceCardAnimal(GameObject GO_ListAnimal,SO_Animal ListDataAnimal)
    {
        GameObject CardAnimal = Instantiate(prefabCardAnimal);
        CardAnimal.transform.SetParent(GO_ListAnimal.transform);
        CardAnimal.transform.localScale = new Vector3(1, 1, 1);
        CardAnimal.GetComponent<ComponentCardAnimalInBook>().ChangeIcon(ListDataAnimal.Icon);
        CardAnimal.GetComponent<ComponentCardAnimalInBook>().ChangeName(ListDataAnimal.NameVn, ListDataAnimal.NameUS);
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
