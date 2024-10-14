
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input for movement on the horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move the player (camera) in the direction of input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply the movement, multiplying by moveSpeed and deltaTime for smooth movement
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
/*
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Speed of player movement
    public Transform cameraTransform;  // Reference to the camera's Transform (drag it in the Inspector)
    
    private Rigidbody rb;  // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input for movement on the horizontal and vertical axes (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal");  // Left/Right movement
        float moveZ = Input.GetAxis("Vertical");    // Forward/Backward movement

        // Calculate movement relative to the camera's forward and right directions
        Vector3 forward = cameraTransform.forward;  // Forward direction of the camera
        Vector3 right = cameraTransform.right;      // Right direction of the camera

        // Normalize forward and right vectors so that they stay consistent even if the camera is tilted
        forward.y = 0f;  // We don't want to move up or down based on camera's vertical tilt
        right.y = 0f;    // Ignore vertical movement on the right direction
        forward.Normalize();
        right.Normalize();

        // Calculate the direction the player should move in
        Vector3 movement = (forward * moveZ + right * moveX).normalized * moveSpeed * Time.fixedDeltaTime;

        // Move the player using Rigidbody's MovePosition (respects physics and collisions)
        rb.MovePosition(rb.position + movement);
    }
}
*/