using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//classe para polimento de sistema de dialogo, ñ está em uso ainda.
[RequireComponent(typeof(TMP_Text))]
public class DialogueText : MonoBehaviour
{
    [SerializeField] private float intervalletter = 2f;
    private TMP_Text textbox;
    
    //awake
    private void Awake() => GetComponent<Text>();
    public IEnumerator ShowText(string content){
        textbox.maxVisibleCharacters = 0;
        textbox.SetText(content);

        yield return RevealChars();
    }

    public void HideText(){
        textbox.SetText("");
        textbox.maxVisibleCharacters = 0;
    }

    public void SkipAnimation() => textbox.maxVisibleCharacters = textbox.textInfo.characterCount;

    private IEnumerator RevealChars(){
        while(textbox.maxVisibleCharacters < textbox.textInfo.characterCount){
            yield return new WaitForSeconds(intervalletter);
            textbox.maxVisibleCharacters++;
        }
    }
}
