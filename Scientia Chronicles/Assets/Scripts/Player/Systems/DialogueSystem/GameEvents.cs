using System;
using UnityEngine;


//gameevents
public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set;}

    private void Awake() => Instance = this;

    public event Action<DiologueData> OnStartDiologue;

    public void StartDialog(DiologueData diologueData) => OnStartDiologue?.Invoke(diologueData);
    public event Action OnFinishDiologue;

    public void FinishDiologue() => OnFinishDiologue?.Invoke();
}
