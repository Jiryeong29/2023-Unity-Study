using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 5.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void LateUpdate()
    {
        // Calculate rotation based on mouse input
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -60.0f, 60.0f);

        // Calculate camera position and rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0.0f);
        Vector3 offset = new Vector3(0.0f, height, -distance);
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

}
