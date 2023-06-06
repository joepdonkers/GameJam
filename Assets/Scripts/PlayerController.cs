using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform cameraTransform; // Reference to the camera transform
    public AudioSource walkingAudio; // Reference to the audio source for walking sound
    public float wobbleAmount = 0.1f; // Amount of camera wobble
    public float wobbleSpeed = 10f; // Speed of camera wobble

    private Rigidbody rb;
    private bool isJumping = false;
    private bool isWalking = false;
    private float originalCameraY; // Original camera position on the Y-axis

private void Start()
{
    rb = GetComponent<Rigidbody>();
    originalCameraY = cameraTransform.localPosition.y;

    // Set the initial rotation of the camera to face forward
    cameraTransform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
}

    private void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Get the forward direction relative to the camera
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f; // Ignore vertical component
        cameraForward.Normalize(); // Normalize to avoid faster diagonal movement

        // Get the right direction relative to the camera
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0f; // Ignore vertical component
        cameraRight.Normalize();

        // Calculate the movement direction based on input and camera orientation
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Play walking sound if the player is moving and not jumping
        if (movement.magnitude > 0 && !isJumping)
        {
            isWalking = true;
            if (!walkingAudio.isPlaying)
            {
                walkingAudio.Play();
            }
        }
        else
        {
            isWalking = false;
            walkingAudio.Stop();
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 1.1f; // Adjust this value depending on your player's size

        // Cast a ray downwards to check if the player is touching the ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // Ignore triggers and the player's own collider
            if (!hit.collider.isTrigger && hit.collider != GetComponent<Collider>())
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void LateUpdate()
    {
        // Apply camera wobble if the player is walking
        if (isWalking)
        {
            float wobbleX = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
            float wobbleY = Mathf.Cos(Time.time * wobbleSpeed * 2) * wobbleAmount * 0.5f;
            cameraTransform.localPosition = new Vector3(wobbleX, originalCameraY + wobbleY, cameraTransform.localPosition.z);
        }
        else
        {
            cameraTransform.localPosition = new Vector3(0f, originalCameraY, cameraTransform.localPosition.z);
        }
    }
}