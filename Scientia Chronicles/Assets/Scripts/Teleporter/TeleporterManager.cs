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
        }
    }

    public Transform SearchPoints(string id){
        if(teleportPoints.TryGetValue(id, out Transform point)){
            return point;
        }
        else
        {
            return null;
        }
    }
}
