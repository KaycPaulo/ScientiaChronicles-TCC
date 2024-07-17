using System;
using System.Collections.Generic;
using UnityEngine;

//scriptable...
[CreateAssetMenu(fileName = "New Dialogue", menuName = "ScriptableObject/Create Dialogue")]
public class DiologueData : ScriptableObject
{
    public List<DiologueSentence> Sentences;
}

[Serializable]
public class DiologueSentence{
    public Talker talkerData;

    [TextArea]
    public List<string>  messages;
}
