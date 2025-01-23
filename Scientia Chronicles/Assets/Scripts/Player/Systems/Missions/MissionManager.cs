using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Mission", menuName = "ScriptableObject/New Mission")]
public class MissionManager : ScriptableObject
{
    public string missionName;
    public bool isCompleted = false;


    public List<MissionItemRequirement> itemRequirements;

    public MissionManager(string missionName)
    {
        this.missionName = missionName;
    }
    public bool ChecKCompletionQuest(InventoryController inventory)
    {

        if (isCompleted)
        {
            return true;
        }

        foreach (var requirement in itemRequirements)
        {
            int itemAmount = inventory.GetItemQuantity(requirement.itens);
            return false;
        }
        
        isCompleted = true;
        return true;
    }


}

[System.Serializable]
public class MissionItemRequirement
{
    public Itens itens;
    public int amount;
}
