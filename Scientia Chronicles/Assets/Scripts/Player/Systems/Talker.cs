using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Person", menuName = "Create Person")]
public class Person : ScriptableObject
{
    public Sprite sprite;
    public string Name;
}
