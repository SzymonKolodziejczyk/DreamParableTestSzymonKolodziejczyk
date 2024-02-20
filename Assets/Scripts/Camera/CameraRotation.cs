using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // The object you want to rotate around
    public float rotationSpeed = 100f; // Speed of rotation

    private Vector3 offset; // Distance between camera and target

    private void Start()
    {
        // Calculate the initial offset between camera and target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Get the horizontal input for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Check if rotation input is not zero
        if (rotationInput != 0f)
        {
            // Calculate the desired rotation angle
            float rotationAngle = rotationInput * rotationSpeed * Time.deltaTime;

            // Determine the rotation direction based on input sign
            int rotationDirection = rotationInput > 0f ? 1 : -1;

            // Rotate the camera around the target in the Y-axis
            transform.RotateAround(target.position, Vector3.up, rotationAngle * rotationDirection);

            // Update the camera position based on the new rotation
            Vector3 newPosition = target.position + Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f) * offset;
            transform.position = newPosition;
        }

        // Make the camera look at the target
        transform.LookAt(target);
    }
}