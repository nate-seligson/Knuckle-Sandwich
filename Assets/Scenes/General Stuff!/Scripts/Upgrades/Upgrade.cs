using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string name;
    public float price;
    public Sprite img;
    public int id;
}
