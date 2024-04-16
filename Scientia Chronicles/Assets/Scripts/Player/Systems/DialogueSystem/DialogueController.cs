using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Image profile;
    [SerializeField] private Text talkerName;

    void Start(){
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
    }

    private void HandleStartDialog(DiologueData data)
    {
        
    }

    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }

    void Update(){

    }

}
