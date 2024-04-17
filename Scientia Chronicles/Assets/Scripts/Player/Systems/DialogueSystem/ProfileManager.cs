using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    private Image profile;
    // Start is called before the first frame update
    private void Awake(){
        profile = GetComponent<Image>();
    }

    void Start(){

    }

    public IEnumerator ShowImage(){
        yield return null;
    }

    public IEnumerator HideImage(){
        yield return null;
    }
}
