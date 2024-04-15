using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[System.Serializable]
public class Dialogue
{

    public Talker talker;
    [UnityEngine.TextArea()]
    public string[] message;
}
