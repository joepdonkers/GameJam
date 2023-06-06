using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object to follow
    public Vector3 offset; // The offset from the target position

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }
}