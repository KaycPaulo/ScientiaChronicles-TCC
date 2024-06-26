using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    [SerializeField] DiologueData ds;
    private bool playerInRange = false;
    private Player player;
    private bool enabled = false;

    private void OnTriggerEnter2D(Collider2D other){
        ChangeState(other);
    }

    private void OnTriggerExit2D(Collider2D other){
        ChangeState(other);
        
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Q) && playerInRange){
            StartDialogue();
        }
    }

    private void ChangeState(Collider2D other){
        Player player;
        
        
       
        if(other.TryGetComponent<Player>(out player)){
            playerInRange = !playerInRange;
        }
        
    }



    private void StartDialogue(){
        GameEvents.Instance.StartDialog(ds);
    }    
}
