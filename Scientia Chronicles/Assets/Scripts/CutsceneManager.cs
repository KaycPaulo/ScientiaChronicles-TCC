using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private DialogueController dialogueController;

    private bool isCutscenePlaying = false;

    public void StartCutscene(){
        if(isCutscenePlaying){
            return;
        }
        isCutscenePlaying = true;
        playableDirector.Play();
        gameObject.SetActive(false);
    }

    public void PauseCutscene(){
        if(isCutscenePlaying){
            playableDirector.Pause();
        }
    }

    public void ResumeCutscene(){
        if(isCutscenePlaying){
            playableDirector.Play();
        }
    }

    private IEnumerator ManageCutscene(){
        yield return new WaitForSeconds(2f);

        dialogueController.HandleStartDialog(new DiologueData());

        yield return new WaitUntil(() => !dialogueController.IsDialogActive);

        ResumeCutscene();
    }
}
