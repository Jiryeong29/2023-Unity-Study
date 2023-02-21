using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform player; // the object to follow
    [SerializeField] private float mouseSensitivity = 100f; // the mouse sensitivity
    [SerializeField] private float distanceFromPlayer = 5f; // the distance from the player
    [SerializeField] private Vector2 pitchMinMax = new Vector2(-40f, 85f); // the minimum and maximum pitch angles

    private float yaw = 0f; // the camera's yaw rotation
    private float pitch = 0f; // the camera's pitch rotation

    private void Start()
    {
        // hide the mouse cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        // get input from the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // calculate the yaw and pitch based on the mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        // calculate the camera position and rotation based on the player's position and the yaw and pitch
        Vector3 targetPosition = player.position - transform.forward * distanceFromPlayer;
        transform.position = targetPosition;
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
