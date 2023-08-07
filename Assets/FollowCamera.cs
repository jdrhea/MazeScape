using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // the thing's position (camera) should be the same as the car's position

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0,-20);
    }
}
