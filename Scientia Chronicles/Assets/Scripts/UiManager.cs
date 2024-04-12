using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject Uicontainer;
    public Image _image;
    public Text _nameP;
    public TMP_Text _dialogue;

    void Awake(){
        DialogueManage.NewTalker += NewTalker;
        //DialogueManage.StartDialogue += ShowText;
    }

    private void NewTalker(Dilogue TalkerInformations){
        _image.sprite = TalkerInformations._talker._sprite;
        _nameP.text = TalkerInformations._talker.name;
        _image.GetComponent<Animator>().SetTrigger("animation");
    }

    private void ShowText(string message) =>  _dialogue.text = message;
    private void ResetText() => _dialogue.text = string.Empty;
    private void UicontainerState(bool state) => Uicontainer.SetActive(state);
}
