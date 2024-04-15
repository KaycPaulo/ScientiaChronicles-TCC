using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [Header("Components")]
    public DialogueContainer dialogueContainer;
    public GameObject dialogueObj;
    private Talker talker;
    public Image profile;
    public Text speechText;
    public Text talkerName;
    
    [Header("Settings")]
    public float typeSpeed;

    private int currentIndex = 0;
  
    public void Speech(Sprite P, string txt, string _talkerName){
        dialogueObj.SetActive(true);
        profile.sprite = P;
        speechText.text = txt;
        talkerName.text = _talkerName;
    }

}
