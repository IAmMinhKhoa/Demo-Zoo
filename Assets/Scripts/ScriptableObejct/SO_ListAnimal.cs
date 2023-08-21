using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ListDataAnimal", menuName = "ScriptableObjects/ListDataAnimal  ")]
[System.Serializable]
public class SO_ListAnimal : ScriptableObject
{
    public List<AnimalZone> List_Animal_Zone;
    



    [System.Serializable]
    public class AnimalZone
    {
        public string NameZone;
        public List<SO_Animal> DATA_Animals;
    }
}
