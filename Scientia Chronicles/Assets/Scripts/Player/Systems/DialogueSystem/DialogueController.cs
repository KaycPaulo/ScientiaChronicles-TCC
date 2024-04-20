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
    [SerializeField] private ProfileManager profileManager;
    [SerializeField] private Image profile;
    [SerializeField] private TMP_Text talkerName;
    [SerializeField] private TMP_Text dialogueText;

    private int index = 0;
    private bool dialogActive = false;

    //private bool dialogActive = false; 
    private float fadeColor = 0.2f;
    private Color colorStart;    
    void Start(){
        colorStart = profile.color;
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
        GameEvents.Instance.OnFinishDiologue += HandleFinishDialog;
    }
    private void HandleStartDialog(DiologueData data)
    {
        StartCoroutine(StartDialog(data));
        //dialogActive = true;
    }
    private void HandleFinishDialog()
    {
        throw new NotImplementedException();
    }

    /*private IEnumerator FadeColor(){
        float elapsedTime = 0f;
        Color targetColor = colorStart;
        targetColor.a = 0f; // Torna a cor final totalmente transparente

        while (elapsedTime < fadeColor)
        {
            // Interpola suavemente entre a cor inicial e a cor final ao longo do tempo
            profile.color = Color.Lerp(colorStart, targetColor, elapsedTime / fadeColor);
            elapsedTime += Time.deltaTime;
            yield return null; // Aguarda até a próxima atualização de frame
        }

        // Garante que a cor final seja definida corretamente após a conclusão da interpolação
        Color finalColor = profile.color;
        finalColor.a = 0f;
        profile.color = finalColor;

    }*/

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
        //StartCoroutine(FadeColor());
        profile.enabled = false;
        yield return dialogueBar.HideBar();

        dialogueText.text = "";
    }

    
    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }
}
