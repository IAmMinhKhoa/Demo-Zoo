using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAnimal", menuName = "ScriptableObjects/DataAnimal  ")]
public class SO_Animal : ScriptableObject
{
    public string Name;
   
    public Sprite Sprite;
    public string Content;
    public AudioClip myAudioClip;

}
