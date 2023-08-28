using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]

public class SO_Animal : ScriptableObject
{
    //Sure Variable
    [Header("Basic information of animal")]
    [SerializeField] protected string ID;
    public bool clock;
    [Header("Names of animal")]
    public string NameVn;
    public string NameUS;
    [Header("Sprites of animal")]
    public Sprite Avatar;
    public Sprite Icon;

    [Header("Sounds of animal")]
    public AudioClip animalSound; //the sound of an animal
    public AudioClip characteristicSound;//dac diem cua dong vat
    public AudioClip storySound;//cau chuyen

    [Header("String of animal")]
    public string Content;
    public string getID()
    {
        return ID;
    }

    public void setID(string ID)
    {
        this.ID = ID;   
    }
}
