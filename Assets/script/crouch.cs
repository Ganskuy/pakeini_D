using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References
    public BoxCollider2D playerCollider;  // The player's collider
    public Animator animator;             // Animator component for animations

    // Collider size variables
    private Vector2 originalSize;         // Original size of the collider
    private Vector2 crouchSize;           // Crouching size of the collider
    private Vector2 originalOffset;       // Original offset of the collider
    private Vector2 crouchOffset;         // Crouching offset of the collider

    // Crouching states
    private bool isCrouching = false;     // Check if player is crouching

    // Ground check and position adjustment
    public LayerMask groundLayer;         // Ground layer for checking ground collision
    private bool isGrounded;              // Check if the player is grounded
    private float groundCheckDistance = 0.05f; // Distance to check for ground

    void Start()
    {
        // Initialize collider sizes and offsets
        originalSize = playerCollider.size;
        originalOffset = playerCollider.offset;

        // Define crouch size and offset (half the height of the original collider)
        crouchSize = new Vector2(originalSize.x, originalSize.y / 2);
        crouchOffset = new Vector2(originalOffset.x, originalOffset.y - originalSize.y / 4);
    }

    void Update()
    {
        // Detect crouch input
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            StandUp();
        }


        // Ensure the character stays grounded
        GroundCheck();
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            // Adjust collider size and offset for crouching
            playerCollider.size = crouchSize;
            playerCollider.offset = crouchOffset;

            // Ensure the player stays grounded by adjusting the position
            StickToGround();

            // Trigger crouch animation
            animator.SetBool("isCrouching", true);

            // Set crouching state
            isCrouching = true;
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            // Reset collider size and offset to original values
            playerCollider.size = originalSize;
            playerCollider.offset = originalOffset;

            // Ensure the player stays grounded by adjusting the position
            StickToGround();

            // Trigger stand-up animation
            animator.SetBool("isCrouching", false);

            // Reset crouching state
            isCrouching = false;
        }
    }
    void GroundCheck()
    {
        // Check if the player is grounded by casting a small ray downward from the player's position
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        // If the ray hits something, the player is grounded
        isGrounded = hit.collider != null;
    }

    void StickToGround()
    {
        // Calculate the difference in collider size
        float sizeDifference = (originalSize.y - crouchSize.y) / 2;

        // Adjust the player's position based on whether they are crouching or standing
        if (isCrouching)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - sizeDifference, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + sizeDifference, transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        // Optional: Visualize the ground check and collider alignment
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - (originalSize.y / 2), transform.position.z));
    }
}