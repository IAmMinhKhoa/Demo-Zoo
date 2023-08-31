using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]

public class SO_Animal : ScriptableObject
{
    [SerializeField] protected string id { get;private set; }
    [SerializeField] protected bool b_Lock;
    [Header("Names of animal")]
    [SerializeField] protected string str_NameVn;
    [SerializeField] protected string str_NameUs;
    [Header("Sprites of animal")]
    [SerializeField] protected Sprite avatar;
    [SerializeField] protected Sprite icon;

    [Header("Audio of animal")]
    [SerializeField] protected AudioClip a_AnimalSound; //the sound of an animal
    [SerializeField] protected AudioClip a_NameVn;
    [SerializeField] protected AudioClip a_NameUs;

    [Header("Information Cluster of animal")] //food, characteristic, conservation status,habitat
    [SerializeField] protected InformationCluster iC_food; //thuc an
    [SerializeField] protected InformationCluster iC_characteristic; //dac diem
    [SerializeField] protected InformationCluster iC_conservation;//tinh trang bao ton
    [SerializeField] protected InformationCluster iC_habitat;//moi truong song


    //get set
    public string Id
    {
        get { return id; }
       
    }

    public bool Lock
    {
        get { return b_Lock; }
        set { b_Lock = value; }
    }

    public string Str_NameVn
    {
        get { return str_NameVn; }
        set { str_NameVn = value; }
    }

    public string Str_NameUs
    {
        get { return str_NameUs; }
        set { str_NameUs = value; }
    }

    public Sprite Avatar
    {
        get { return avatar; }
        set { avatar = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public AudioClip A_AnimalSound
    {
        get { return a_AnimalSound; }
        set { a_AnimalSound = value; }
    }

    public AudioClip A_NameVn
    {
        get { return a_NameVn; }
        set { a_NameVn = value; }
    }

    public AudioClip A_NameUs
    {
        get { return a_NameUs; }
        set { a_NameUs = value; }
    }

    public InformationCluster IC_Food
    {
        get { return iC_food; }
        set { iC_food = value; }
    }

    public InformationCluster IC_Characteristic
    {
        get { return iC_characteristic; }
        set { iC_characteristic = value; }
    }

    public InformationCluster IC_Conservation
    {
        get { return iC_conservation; }
        set { iC_conservation = value; }
    }

    public InformationCluster IC_Habitat
    {
        get { return iC_habitat; }
        set { iC_habitat = value; }
    }

    [System.Serializable]
    public class InformationCluster //cum thong tin
    {
        public string Str_Content;
        public AudioClip A_audio;
        public List<Sprite> L_Sprite;
    }
}
