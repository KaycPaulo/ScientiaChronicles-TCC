using UnityEngine;

public class camPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform target;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector2(target.position.x,target.position.y);
    }
}
