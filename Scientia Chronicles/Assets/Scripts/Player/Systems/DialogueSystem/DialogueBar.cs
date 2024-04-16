using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DialogueBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Image talkerProfile;
    private RectTransform rectTransform;
    private Vector2 HiddenPosition = new Vector2(0, -165);
    private Vector2 VisiblePosition = Vector2.zero;
    private void Awake(){
        talkerProfile = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        rectTransform.anchoredPosition = HiddenPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
