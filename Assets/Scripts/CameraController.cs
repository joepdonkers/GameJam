using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The object the camera will follow
    public float smoothSpeed = 8f; // The smoothing factor for camera movement
    public Vector3 offset; // The offset from the target's position

    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Use SmoothDamp to smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Rotate the camera to match the target's rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeed * Time.deltaTime);
    }
}