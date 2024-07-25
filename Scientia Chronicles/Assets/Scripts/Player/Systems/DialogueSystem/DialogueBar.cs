using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DialogueBar : MonoBehaviour
{
    
    
    private Image dialogBox;
    private RectTransform rectTransform;
    private Vector2 HiddenPosition = new Vector2(0, -165);
    private Vector2 VisiblePosition = new Vector2(0, 165);
    public Talker talkerDt;
    private float animationspeed = 300;
    private void Awake(){
        dialogBox = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        rectTransform.anchoredPosition = HiddenPosition;
    }

    public IEnumerator ShowBar(){
        while(rectTransform.anchoredPosition.y < VisiblePosition.y){
            rectTransform.anchoredPosition += Vector2.up * animationspeed * Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = VisiblePosition;
    }



    public IEnumerator HideBar(){
        while(rectTransform.anchoredPosition.y > HiddenPosition.y){
            rectTransform.anchoredPosition -= Vector2.up * animationspeed * Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = HiddenPosition;
    }

}
