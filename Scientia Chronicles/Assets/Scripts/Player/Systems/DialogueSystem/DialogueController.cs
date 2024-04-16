using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueBar dialogueBar;
    [SerializeField] private Image profile;
    [SerializeField] private Text talkerName;
    [SerializeField] private Text dialogueText;
    [SerializeField] private ProfileBox profileBox;

    void Start(){
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
    }

    private void HandleStartDialog(DiologueData data)
    {
        StartCoroutine(StartDialog(data));
        
    }

    private IEnumerator StartDialog(DiologueData data){
        yield return dialogueBar.ShowBar();
    }

    private IEnumerator EndDialog(){
        yield return dialogueBar.HideBar();
    }

    private void OnDestroy(){
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
    }

    void Update()
    {
        // Obtenha a posição atual da caixa de diálogo
        Vector2 dialogBoxPosition = dialogueBar.GetComponent<RectTransform>().anchoredPosition;
        // Atualize a posição da imagem para coincidir com a posição da caixa de diálogo
        dialogueBar.UpdateImagePosition(dialogBoxPosition);
    }

}
