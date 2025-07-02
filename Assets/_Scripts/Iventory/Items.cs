using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items")]
public class Items : ScriptableObject
{
    public int id;
    public string name;
    public int value;
    public Sprite image;
}
