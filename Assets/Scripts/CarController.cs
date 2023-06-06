using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Get input axes
        float moveAxis = Input.GetAxis("Vertical");
        float rotationAxis = Input.GetAxis("Horizontal");

        // Move the car forward or backward
        transform.Translate(Vector3.forward * moveAxis * moveSpeed * Time.deltaTime);

        // Rotate the car
        transform.Rotate(Vector3.up * rotationAxis * rotationSpeed * Time.deltaTime);
    }
}