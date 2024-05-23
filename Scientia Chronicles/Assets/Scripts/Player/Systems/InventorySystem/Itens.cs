using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MaterialType{
    none,
    Minerals,
    animals,
    Natural,
    synthetics
}

[CreateAssetMenu(fileName ="New item", menuName ="ScriptableObject/Create Item")]
public class Itens : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public MaterialType materialType;
    public int ID{get; private set;}

    private void OnEnable() =>
    ID = this.GetInstanceID();
}
