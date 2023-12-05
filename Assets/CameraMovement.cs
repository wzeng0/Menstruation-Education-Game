using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the movement speed
    public GameObject arrow;
    void Awake()
    {
        arrow.SetActive(false);
    }

    void Update()
    {
        // Get user input for movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

        // Move the camera based on the input
        MoveCamera(moveDirection);
    }

    public void MoveCamera(Vector3 moveDirection)
    {
        // Calculate the new position of the camera
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        if (newPosition.x >= -12.5 && newPosition.x <= -11) {
            arrow.SetActive(true);
        } else {
            arrow.SetActive(false);
        }

        // Update the position of the camera
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }
}
