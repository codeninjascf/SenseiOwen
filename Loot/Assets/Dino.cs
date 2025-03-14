using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dino", menuName = "ScriptableObjects/createDino", order = 1)]
public class Dino : ScriptableObject
{
    public new string name;
    public Sprite image;
    public float sellValue;
}
