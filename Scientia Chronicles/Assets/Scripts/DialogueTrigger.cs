using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueContainer dialogueContainer;
    // Start is called before the first frame update
    void Start()
    {
        DialogueManage.Instance.StartConversation(dialogueContainer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
