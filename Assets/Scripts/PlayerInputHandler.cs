using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        // Check which direction the sprite should be facing and flip accordingly.
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = true; //Moving right, flip.
        } 
        else if (moveInput.x < 0) 
        {
            spriteRenderer.flipX = false; // Moving left, do not flip.
        }
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
