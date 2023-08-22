using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]

public class SO_Animal : ScriptableObject
{
    public bool clock;
    public string NameVn;
    public string NameUS;
    public Sprite Sprite;
    public Sprite Icon;
    public string Content;
    public AudioClip myAudioClip;

}
