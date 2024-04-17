using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueBar dialogueBar;
    [SerializeField] private DiologueData diologueData;
    [SerializeField] private Image profile;
    [SerializeField] private TMP_Text talkerName;
    [SerializeField] private Text dialogueText;
    //[SerializeField] private float intervalBetween = 1;

    void Start(){
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
    }

    private void HandleStartDialog(DiologueData data)
    {
        StartCoroutine(StartDialog(data));
        
    }

    private IEnumerator StartDialog(DiologueData data){
        yield return dialogueBar.ShowBar();
        foreach (var sentence in data.Sentences)
        {
            talkerName.SetText(sentence.talkerData.talkerName);
            profile.sprite = sentence.talkerData.sprite;
            dialogueText.text = sentence.messages;  
        }
        
        //yield return dialogueBar.HideBar();
    }

    private IEnumerator EndDialog(){
        yield return dialogueBar.HideBar();
    }

    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }
}
