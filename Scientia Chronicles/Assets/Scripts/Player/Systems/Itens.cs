using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum MaterialType{
    metal,
    plant,
    synthetic
}

[CreateAssetMenu(fileName = "New Item", menuName ="Create Item")]
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
