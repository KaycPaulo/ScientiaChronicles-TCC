using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

public class Player : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 movement = new Vector3(Input.GetAxis("Horizontal")* speed, Input.GetAxis("Vertical")* speed, 0f);
    }
}
