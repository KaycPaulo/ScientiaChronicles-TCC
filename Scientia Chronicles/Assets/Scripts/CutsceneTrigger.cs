using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector; // Controlador da cutscene
    public List<DiologueData> dialogues;
    [SerializeField] private StartTransitionManager startTransition;
    public bool PlayOnce = true; // Define se o gatilho será executado apenas uma vez
    private bool hasPlayed = false; // Controle para evitar repetição
    private DialogueController dialogueController; // Referência ao controlador de diálogo
    private Dictionary<DiologueData, bool> dialogueUsed = new Dictionary<DiologueData, bool>(); // Controle de diálogos usados

    private void Start()
    {
        // Obtém o DialogueController presente na cena
        dialogueController = FindObjectOfType<DialogueController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player) && (!PlayOnce || !hasPlayed))
        {
            hasPlayed = true;
            StartCoroutine(HandleCutscene());
        }
    }

    private void StartDialogue()
    {
        foreach (var dialogue in dialogues)
        {
            if (CanUseDialogue(dialogue))
            {
                dialogueController.HandleStartDialog(dialogue); // Inicia o diálogo
                if (!dialogue.CanRepeat)
                {
                    MarkDialogueAsUsed(dialogue); // Marca o diálogo como usado
                }
                break;
            }
        }
    }

    private IEnumerator HandleCutscene()
    {
        yield return StartCoroutine(startTransition.FadeOut());

        if (playableDirector != null)
        {
            playableDirector.Play();
        }

        StartDialogue();

        yield return StartCoroutine(startTransition.FadeIn());
    }

    private bool CanUseDialogue(DiologueData dialogue)
    {
        // Permite repetir o diálogo se ele for configurado como repetível
        if (dialogue.CanRepeat)
        {
            return true;
        }

        // Permite usar o diálogo se ele ainda não foi utilizado
        return !dialogueUsed.ContainsKey(dialogue) || !dialogueUsed[dialogue];
    }

    private void MarkDialogueAsUsed(DiologueData dialogue)
    {
        if (!dialogueUsed.ContainsKey(dialogue))
        {
            dialogueUsed.Add(dialogue, true);
        }
    }
}
