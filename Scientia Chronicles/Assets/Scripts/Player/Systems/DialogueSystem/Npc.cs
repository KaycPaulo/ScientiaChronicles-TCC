using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] DiologueData ds;

    private void OnTriggerEnter2D(Collider2D other){
        Player player;
        if(other.TryGetComponent<Player>(out player)){
            Debug.Log("Player is Near");
            GameEvents.Instance.StartDialog(ds);
        }
    }
    
}
