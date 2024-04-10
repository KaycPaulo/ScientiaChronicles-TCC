using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, target.position.z);
    }
}
