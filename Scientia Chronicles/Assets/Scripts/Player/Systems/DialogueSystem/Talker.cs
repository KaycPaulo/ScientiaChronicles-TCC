using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Talker", menuName = "Create Talker")]
public class Talker : ScriptableObject
{
    public Sprite sprite;
    public string talkerName;
}
