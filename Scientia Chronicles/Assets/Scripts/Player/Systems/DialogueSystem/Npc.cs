using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private List<DiologueData> dialogues; // Lista de diálogos do NPC
    [SerializeField] private MissionManager currentMission;
    [SerializeField] private InventoryController inventory;
    private bool playerInRange = false;
    private Player player;
    private Dictionary<DiologueData, bool> dialogueUsed = new Dictionary<DiologueData, bool>(); // Marca se um diálogo foi usado

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out player))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out player))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerInRange)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        bool dialogueStarted = false;

        for (int i = 0; i < dialogues.Count; i++)
        {
            var dialogue = dialogues[i];

            if (CanUseDialogue(dialogue))
            {
                GameEvents.Instance.StartDialog(dialogue);
                dialogueStarted = true;

                
                if (!dialogue.CanRepeat)
                {
                    if(currentMission == null){
                        MarkDialogueAsUsed(dialogue);
                    }
                    
                    // if(currentMission.isCompleted){

                    // }
                    // else{
                    //     if(currentMission.ChecKCompletionQuest(inventory)){
                    //         currentMission.
                    //     }
                    // }
                    
                }
                break;
            }
        }
    }

    private bool CanUseDialogue(DiologueData dialogue)
    {
        
        if (dialogue.CanRepeat)
        {
        
            return true;
        }

        
        if (!dialogueUsed.ContainsKey(dialogue) || !dialogueUsed[dialogue])
        {
            return true; 
        }

        return false; 
    }

    private void MarkDialogueAsUsed(DiologueData dialogue)
    {
        if (!dialogueUsed.ContainsKey(dialogue))
        {
            dialogueUsed.Add(dialogue, true);;
        }
    }
}
