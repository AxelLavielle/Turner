using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField]
    private float dampTime;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private int cameraPositionThresholdY;
    [SerializeField]
    private int cameraPositionThresholdX;
    [SerializeField]
    private int cameraPositionThresholdMaxX;


    void FixedUpdate()
    {
        //We get the position of the target
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
        //We get the delta (point between target & camera)
        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        //We form the destination from our position to the delta
        Vector3 destination = transform.position + delta;
        //We go to it
        destination.y /= 3;
        if (destination.x < cameraPositionThresholdX)
            destination.x = cameraPositionThresholdX;
        else if (destination.x > cameraPositionThresholdMaxX)
            destination.x = cameraPositionThresholdMaxX;
        if (destination.y < cameraPositionThresholdY)
            destination.y = cameraPositionThresholdY;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
