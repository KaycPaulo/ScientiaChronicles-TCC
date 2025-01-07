using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPoint : MonoBehaviour
{
    public string id;
    void Start()
    {
        TeleporterManager.Instance.RegisterPoint(id, transform);
    }
}
