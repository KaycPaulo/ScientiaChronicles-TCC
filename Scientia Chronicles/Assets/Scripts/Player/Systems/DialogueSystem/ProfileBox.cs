using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProfileBox : MonoBehaviour
{

    // Start is called before the first frame update
    private Image profile;
    private RectTransform rectTransform;
    private Vector2 HiddenPosition = new Vector2(430, -533);
    private Vector2 VisiblePosition = new Vector2(430, 0);
    private float animationspeed = 100;
    private void Awake()
    {
        profile = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        rectTransform.anchoredPosition = HiddenPosition;
    }

    public IEnumerator ShowProfile(){
        while(rectTransform.anchoredPosition.y < VisiblePosition.y){
            rectTransform.anchoredPosition += Vector2.up * animationspeed * Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = VisiblePosition;
    }


    public IEnumerator HideProfile(){
        while(rectTransform.anchoredPosition.y > HiddenPosition.y){
            rectTransform.anchoredPosition -= Vector2.up * animationspeed * Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = HiddenPosition;
    }


}
