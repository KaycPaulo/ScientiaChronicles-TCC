using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProfileManager : MonoBehaviour
{
    private Image profile;
    
    private RectTransform rectTransform;
    private Vector2 HiddenPosition = new Vector2(0, -165);
    private Vector2 VisiblePosition = new Vector2(0, 165);
    private float animationspeed = 300;
    // Start is called before the first frame update
    private void Awake(){
        profile = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start(){
        rectTransform.anchoredPosition = HiddenPosition;
    }

    public IEnumerator ShowImage(){
        
        while(rectTransform.anchoredPosition.x < VisiblePosition.x){
            rectTransform.anchoredPosition += Vector2.left * animationspeed * Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = VisiblePosition;
    }

    public IEnumerator HideImage(){
        while(rectTransform.anchoredPosition.x > HiddenPosition.x){
            rectTransform.anchoredPosition -= Vector2.up * animationspeed * Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = HiddenPosition;
    }
}
