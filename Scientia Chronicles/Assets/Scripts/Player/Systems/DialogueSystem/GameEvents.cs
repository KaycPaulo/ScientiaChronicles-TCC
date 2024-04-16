using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set;}

    private void Awake() => Instance = this;

    public event Action<DiologueData> OnStartDiologue;

    public void StartDialog(DiologueData diologueData) => OnStartDiologue?.Invoke(diologueData);
    public event Action OnFinishDiologue;

    private void FinishDiologue() => OnFinishDiologue?.Invoke();
}
