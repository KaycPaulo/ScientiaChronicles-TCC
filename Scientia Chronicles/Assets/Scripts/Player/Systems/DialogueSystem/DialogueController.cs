using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;



public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueBar dialogueBar;
    [SerializeField] private DiologueData diologueData;
    [SerializeField] private Image profile;
    [SerializeField] private TMP_Text talkerName;
    [SerializeField] private TMP_Text dialogueText;

   
    private bool dialogActive = false;
    
    void Start(){
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
        GameEvents.Instance.OnFinishDiologue += HandleFinishDialog;
    }
    private void HandleStartDialog(DiologueData data)
    {
        StartCoroutine(StartDialog(data));
    }
    private void HandleFinishDialog()
    {
        throw new NotImplementedException();
    }


    private IEnumerator StartDialog(DiologueData data){
        
        dialogActive = true;
        profile.enabled = false;
        talkerName.text = "";

        yield return dialogueBar.ShowBar();
        profile.enabled = true;
        foreach (var sentence in data.Sentences)
        {

            talkerName.SetText(sentence.talkerData.talkerName);
            profile.sprite = sentence.talkerData.sprite;

            foreach(string message in sentence.messages) {
                yield return dialogueText.text = message;
                yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
                
                if(!dialogActive) break;
            }
        }

        profile.enabled = false;
        yield return dialogueBar.HideBar();
        talkerName.text = "";
        dialogueText.text = "";
    }

    
    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }
}
