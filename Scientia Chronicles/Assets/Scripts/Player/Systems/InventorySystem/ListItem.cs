using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New ItemList", menuName = "ScriptableObject/Create Item List")]
public class ListItem : ScriptableObject
{
    public List<Itens> itens;  // Lista de itens que você vai preencher no Inspector
}
