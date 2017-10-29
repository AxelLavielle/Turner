using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float dampTime;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    void FixedUpdate()
    {
        //We get the position of the target
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
        //We get the delta (point between target & camera)
        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        //We form the destination from our position to the delta
        Vector3 destination = transform.position + delta;
        //We go to it
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
