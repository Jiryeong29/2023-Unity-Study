using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{


   [SerializeField] private float moveSpeed = 5f; // the speed at which the object moves

    private Rigidbody rb; // reference to the rigidbody component

    private void Start()
    {
        // get reference to the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // get input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // calculate the move direction based on the camera orientation and the input
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        Vector3 cameraRight = Camera.main.transform.right;
        Vector3 moveDirection = (horizontalInput * cameraRight + verticalInput * cameraForward).normalized;

        // set the player's rotation to face the same direction as the camera
        transform.rotation = Quaternion.LookRotation(cameraForward);

        // move the player in the move direction
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        // Add your rendering code here
    }
}
