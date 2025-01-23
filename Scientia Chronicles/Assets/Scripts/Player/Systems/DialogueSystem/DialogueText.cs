using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class DialogueText : MonoBehaviour
{
    [SerializeField] private float intervalLetter = 0.001f; 
    private TMP_Text textbox;

    private void Awake() => textbox = GetComponent<TMP_Text>();

    
    public IEnumerator ShowText(string content)
    {
        textbox.text = content; 
        textbox.maxVisibleCharacters = 0;
        
        yield return new WaitForSeconds(0.01f);

        yield return RevealChars(); 
    }

    public void HideText()
    {
        textbox.SetText("");
        textbox.maxVisibleCharacters = 0;
    }

    public void SkipAnimation() => textbox.maxVisibleCharacters = textbox.textInfo.characterCount;

    private IEnumerator RevealChars()
    {
        while (textbox.maxVisibleCharacters < textbox.textInfo.characterCount)
        {
            yield return new WaitForSeconds(intervalLetter); 
            textbox.maxVisibleCharacters++;
        }
    }
}
