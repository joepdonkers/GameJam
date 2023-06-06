using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // Offset is the distance between the camera and the player
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = player.transform.position + offset;

        // Set the camera's position to the target position
        transform.position = targetPosition;
    }
}