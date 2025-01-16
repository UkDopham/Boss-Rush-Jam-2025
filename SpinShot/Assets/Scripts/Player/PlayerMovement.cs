using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    private float mouseSensitivity = 400.0f; // Sensitivity for mouse movement
    private Transform playerCamera; // Reference to the player's camera
    private float xRotation = 0.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing from the player.");
        }

        playerCamera = Camera.main.transform;
        if (playerCamera == null)
        {
            Debug.LogError("No main camera found. Ensure the camera has the tag 'MainCamera'.");
        }
    }

    void Update()
    {
        LookAround();
        Movement();
    }

    private void LookAround()
    {
        if (playerCamera == null)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Rotate player horizontally
    }

    private void Movement()
    {
        if (controller == null)
        {
            return;
        }

        // Check if the player is grounded
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;// Reset vertical velocity when grounded
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
