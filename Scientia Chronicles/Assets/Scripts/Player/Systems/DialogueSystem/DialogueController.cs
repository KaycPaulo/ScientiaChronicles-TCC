using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
    [SerializeField] private Text dialogueText;
    [SerializeField] private float intervalletter = 1f;
    public Text button;
    public bool spacePressed = false;
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

            foreach (string message in sentence.messages) {
                dialogueText.text = message;
                yield return new WaitForSeconds(5f);
            } 
        }
        
       yield return dialogueBar.HideBar();
    }

    private IEnumerator EndDialog(){
        yield return null;
    }

    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }
}
