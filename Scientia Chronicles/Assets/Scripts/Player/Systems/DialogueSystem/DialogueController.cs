using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueBar dialogueBar;
    [SerializeField] private Image profile;
    [SerializeField] private TMP_Text talkerName; 
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private GameObject optionsPanel;    [SerializeField] private Button optionButtonPrefab;
    
    public bool IsDialogActive {get; private set;}
    private Player player; 
    private bool dialogActive = false; 
    private bool waitingChoice = false;
    private bool hasBeenDisplayed = false;

    void Start()
    {
        player = FindObjectOfType<Player>(); 
        GameEvents.Instance.OnStartDiologue += HandleStartDialog;
        GameEvents.Instance.OnFinishDiologue += HandleFinishDialog;

        optionsPanel.SetActive(false); 
    }

    public void HandleStartDialog(DiologueData data)
    {

        if(data.CanRepeat == false && hasBeenDisplayed){
            return;
        }

        player.DisableMovement(); 
        StartCoroutine(StartDialog(data));
    }

    public void HandleFinishDialog()
    {
        dialogActive = false;
        profile.enabled = false;
        talkerName.text = "";
        dialogueText.HideText();
        optionsPanel.SetActive(false);
        player.EnableMovement();


        hasBeenDisplayed = true;
    }

    public IEnumerator StartDialog(DiologueData data)
    {
        dialogActive = true;
        profile.enabled = false;
        talkerName.text = "";

        yield return dialogueBar.ShowBar(); 
        profile.enabled = true;

        if(!data.CanRepeat && !hasBeenDisplayed){
            hasBeenDisplayed = true;
        }

        foreach (var sentence in data.Sentences)
        {
            
            talkerName.SetText(sentence.talkerData.talkerName);
            profile.sprite = sentence.talkerData.sprite;

            foreach (string message in sentence.messages)
            {
                yield return StartCoroutine(dialogueText.ShowText(message));
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); 
            }

            
            if (sentence.isQuestion && sentence.playerChoices != null && sentence.playerChoices.Count > 0)
            {
                optionsPanel.SetActive(true);
                waitingChoice = true;

               
                foreach (Transform child in optionsPanel.transform)
                {
                    child.gameObject.SetActive(false); 
                }

                
                foreach (var choice in sentence.playerChoices)
                {
                    // Tenta pegar um botão inativo para reutilizar
                    Button button = GetInactiveButton();
                    if (button == null)
                    {
                        button = Instantiate(optionButtonPrefab, optionsPanel.transform); 
                    }

                    button.gameObject.SetActive(true); 

                    
                    TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
                    if (buttonText != null)
                    {
                        buttonText.gameObject.SetActive(true); 
                        buttonText.text = choice.choiceText;
                    }

                    
                    Image buttonImage = button.GetComponent<Image>();
                    if (buttonImage != null)
                    {
                        buttonImage.enabled = true; 
                    }

                    button.interactable = true;
                    button.onClick.AddListener(() => OnPlayerChoiceSelected());
                }

                yield return new WaitUntil(() => !waitingChoice);
            }
        }

        HandleFinishDialog(); 
        yield return dialogueBar.HideBar();
        IsDialogActive = false;
    }

    public void PauseDialogue(){
        dialogActive = false;
    }

    public void ResumeDialogue(){
        dialogActive = true;
    }

    private void OnPlayerChoiceSelected()
    {
        waitingChoice = false;

        foreach (Transform child in optionsPanel.transform)
        {
            child.gameObject.SetActive(false);
        }

        optionsPanel.SetActive(false);
    }

    private Button GetInactiveButton()
    {
        foreach (Transform child in optionsPanel.transform)
        {
            if (!child.gameObject.activeSelf)
            {
                return child.GetComponent<Button>();
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnStartDiologue -= HandleStartDialog;
        GameEvents.Instance.OnFinishDiologue -= HandleFinishDialog;
    }
}
