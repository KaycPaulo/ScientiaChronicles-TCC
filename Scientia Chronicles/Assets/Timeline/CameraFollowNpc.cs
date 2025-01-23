using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraFollowNpc : MonoBehaviour
{
    public Transform npcToFollow;
    public float smoothSpeed = 0.125f;
    public Vector2 offset;

    private bool isFollowing = true;

    public void LateUpdate()
    {
        if (npcToFollow != null)
        {
            Vector3 desiredPosition = new Vector3(npcToFollow.position.x + offset.x, npcToFollow.position.y + offset.y, transform.position.z);


            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }

    public void SetFollowing(bool follow){
        isFollowing = follow;
    }
}