using UnityEngine;



public enum MaterialType
{
    none,
    Minerals,
    animals,
    Natural,
    synthetics
}

[CreateAssetMenu(fileName = "New item", menuName = "ScriptableObject/Create Item")]
public class Itens : ScriptableObject
{
    public Sprite sprite;
    public string name;
    public string Description;
    public MaterialType materialType;
    public bool isStack;
    public int id { get; private set; }

    private void OnEnable() =>
    id = this.GetInstanceID();
}