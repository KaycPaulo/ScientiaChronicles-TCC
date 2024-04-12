using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static DialogueManage Instance;

    public static event System.Action<Dilogue> NewTalker;
    public static event System.Action ResetText;
    private static event System.Action<string> ShowMessage;
    private static event System.Action<bool> UIstate;
    private DialogueContainer currentDialogue;
    private bool endCurrentTalk = true;
    void Awake(){
        Instance = this;
    }

    public void StartConversation(DialogueContainer container){
        currentDialogue = container;
        StartCoroutine(StartDialogue());
        UIstate?.Invoke(true);
    }

    private IEnumerator StartDialogue(){
        for(int i = 0;i < currentDialogue.dialogues.Length; i++){
            ResetText?.Invoke();
            NewTalker?.Invoke(currentDialogue.dialogues[i]);
            //ShowDialogue(currentDialogue.dialogues[i].messages);
            StartCoroutine(ShowDialogue(currentDialogue.dialogues[i].messages));
            yield return new WaitUntil(() => endCurrentTalk);
        }
        UIstate?.Invoke(false);
    }
    private IEnumerator ShowDialogue(string[] messages){
        endCurrentTalk = false;

        foreach(var message in messages){
            ShowALLMessage(message);
            yield return new WaitUntil(() => endCurrentTalk);
        }
        endCurrentTalk = true;
    }

    private void ShowALLMessage(string message){
       ShowMessage?.Invoke(message); 
    }

}
