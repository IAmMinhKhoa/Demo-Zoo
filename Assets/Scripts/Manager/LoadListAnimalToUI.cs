using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static SO_ListAnimal;

public class LoadListAnimalToUI : MonoBehaviour
{
    public SO_ListAnimal listAnimal;
    public GameObject prefabCardAnimal;
    [Header("Need to enter NameZone(Environment Name)")]
    public string NameZone;
    [Header("Need Drag Area_Map_'NameZone' of that environment")]
    public GameObject GO_AreaMap; //GO=GameObject
    protected GameObject GO_ListAnimal;
    private void Start()
    {
        LoadData();
        
    }
    protected void LoadData()
    {
        bool checkFindZone=false;
        GO_ListAnimal = FindChildObject(GO_AreaMap, "List Animal");
        
        foreach (AnimalZone ListZone in listAnimal.List_Animal_Zone)
        {
            if(ListZone.NameZone == NameZone)
            {
                checkFindZone = true;
                foreach  (SO_Animal ListDataAnimal in ListZone.DATA_Animals)
                {
                   GameObject CardAnimal = Instantiate(prefabCardAnimal);
                    CardAnimal.GetComponent<ComponentCardAnimalInBook>().ChangeIcon(ListDataAnimal.Icon);
                    CardAnimal.GetComponent<ComponentCardAnimalInBook>().ChangeName(ListDataAnimal.NameVn, ListDataAnimal.NameUS);
                    CardAnimal.transform.SetParent(GO_ListAnimal.transform);
                }
            }
        }
        if (checkFindZone != true)
        {
            Debug.LogWarning("Not Finding this " + NameZone);
        }
    }


    protected GameObject FindChildObject(GameObject parent,string name)
    {
        Transform childObject = parent.transform.Find(name);
        if (childObject != null)
        {
            // ?ã tìm th?y ??i t??ng con có tên "a"
            // Th?c hi?n các thao tác khác v?i childObject
            return childObject.gameObject;
        }
        else
        {
            // Không tìm th?y ??i t??ng con có tên "a"
            return null;
        }
    }
}
