using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollowing : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}
