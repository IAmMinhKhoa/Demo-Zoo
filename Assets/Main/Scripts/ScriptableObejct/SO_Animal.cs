using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]

public class SO_Animal : ScriptableObject
{
    [SerializeField] protected string ID { get;private set; }
    public bool clock;
    [Header("Names of animal")]
    public string Str_NameVn;
    public string Str_NameUs;
    [Header("Sprites of animal")]
    public Sprite Avatar;
    public Sprite Icon;

    [Header("Audio of animal")]
    public AudioClip A_AnimalSound; //the sound of an animal
    public AudioClip A_NameVn;
    public AudioClip A_NameUs;

    [Header("Information Cluster of animal")] //food, characteristic, conservation status,habitat
    public InformationCluster IC_food; //thuc an
    public InformationCluster IC_characteristic; //dac diem
    public InformationCluster IC_conservation;//tinh trang bao ton
    public InformationCluster IC_habitat;//moi truong song
  

    [System.Serializable]
    public class InformationCluster //cum thong tin
    {
        public string Str_Content;
        public AudioClip A_audio;
        public List<Sprite> L_Sprite;
    }
}
