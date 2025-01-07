using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    public  static TeleporterManager Instance;
    private Dictionary<string, Transform> teleportPoints = new Dictionary<string, Transform>();
    private void Awake()
    {
        if(Instance == null){
            Instance  = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void RegisterPoint(string id, Transform point){
        if (!teleportPoints.ContainsKey(id))
        {
            teleportPoints.Add(id, point);
             Debug.Log($"Ponto de teleporte registrado: ID = {id}, Posição = {point.position}");
        }
        else{
            Debug.LogWarning($"Ponto de teleporte com ID '{id}' já foi registrado.");
        }
    }

    public Transform SearchPoints(string id){
        if(teleportPoints.TryGetValue(id, out Transform point)){
            return point;
        }
        else
        {
            Debug.LogWarning($"Ponto de teleporte com ID '{id}' não encontrado.");
            return null;
        }
    }
}
