using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer[] spriteRenderers;
    private bool isFlipped = false;

    [SerializeField] Transform arm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        // Check which direction the sprite should be facing and flip accordingly.
        if (moveInput.x > 0 && isFlipped)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = false; //Moving right, flip right.
                isFlipped = false;
            }
        } 
        else if (moveInput.x < 0 && !isFlipped) 
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = true; //Moving left, flip left.
                isFlipped = true;
            }
        }
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAim(InputValue value)
    {
        Vector2 aimDirection = value.Get<Vector2>();

        if (aimDirection.sqrMagnitude > 0.01f) // Only rotate if there's significant input
        {
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            arm.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
