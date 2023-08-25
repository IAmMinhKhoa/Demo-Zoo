using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]

public class SO_Animal : ScriptableObject
{
    //Sure Variable
    protected string ID;
    public bool clock;
    public string NameVn;
    public string NameUS;
    public Sprite Sprite;
    public Sprite Icon;

    //waitting considering variable
    public string Content;
    public AudioClip animalSound;


    public string getID()
    {
        return ID;
    }

    public void setID(string ID)
    {
        this.ID = ID;   
    }
}
