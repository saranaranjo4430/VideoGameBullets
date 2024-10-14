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
