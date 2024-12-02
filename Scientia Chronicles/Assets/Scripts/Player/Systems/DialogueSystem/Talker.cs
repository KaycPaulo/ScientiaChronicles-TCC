using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Talker", menuName = "ScriptableObject/Create Talker")]
public class Talker : ScriptableObject
{
    public Sprite sprite;
    public string talkerName;
}
