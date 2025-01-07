using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEditorInternal;

public class StartTransitionManager : MonoBehaviour
{

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        if(fadeImage != null){
            fadeImage.gameObject.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeIn(){
        float timeElapsed = 0;
        Color startColor = fadeImage.color;
        startColor.a = 1f;
        fadeImage.color = startColor;

        while(timeElapsed < fadeDuration){
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed/fadeDuration);
            fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut(){
        fadeImage.gameObject.SetActive(true);
        float timeElapsed = 0f;
        Color startColor = fadeImage.color;
        startColor.a = 0f;
        fadeImage.color = startColor;

        while(timeElapsed < fadeDuration){
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
    
    public void TransitionToScene(string sceneName){
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName){
        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(sceneName);

        yield return new WaitForSeconds(0.1f);

        yield return StartCoroutine(FadeIn());
    }
}
