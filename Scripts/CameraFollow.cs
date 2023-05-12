using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float horizontalSpeed = 1f;
    public float fixedVerticalPosition = 5f;

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        // Check if the player is moving horizontally
        if (horizontalMove != 0)
        {
            Vector3 horizontalVector = new Vector3(horizontalMove * horizontalSpeed, 0f, 0f);
            Vector3 desiredPosition = target.position + offset + horizontalVector;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the y position of the camera to fixedVerticalPosition
            smoothedPosition.y = fixedVerticalPosition;

            transform.position = smoothedPosition;
        }
    }
}
