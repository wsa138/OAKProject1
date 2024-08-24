using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isFlippedLeft = false;
    private Vector3 originalScale;
    Animator bodyAnimator;
    Animator armAnimator;

    [SerializeField] Transform arm;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject projectilePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Store the original local scale of Player object
        originalScale = transform.localScale;

        // Get all animators on character
        bodyAnimator = GetComponent<Animator>();
        armAnimator = arm.GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAim(InputValue value)
    {
        Vector2 aimDirection = value.Get<Vector2>();
        
        // Set animator states based on aiming.
        if (aimDirection.x == 0 && aimDirection.y == 0)
        {
            bodyAnimator.SetBool("isAiming", false);
            if (armAnimator != null)
            {
                armAnimator.enabled = true;
            }            
        }
        else
        {
            bodyAnimator.SetBool("isAiming", true);
            if (armAnimator != null) 
            {
                armAnimator.enabled = false;
            }            
        }

        if (aimDirection.sqrMagnitude > 0.01f) // Only rotate if there's significant input
        {
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            // Adjust the angle based on the flip state
            if (!isFlippedLeft)
            {
                angle = 180 - angle; // Invert the angle if flipped
            }

            // Correct the vertical inversion
            if (transform.localScale.x < 0)
            {
                angle = -angle; // Invert vertically
            }

            arm.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Flip the player based on aim, rotate firePoint
        if (aimDirection.x < 0 && isFlippedLeft)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); // Flip player to Left
            firePoint.localRotation = Quaternion.Euler(0, 0, 180); // Rotate firePoint by 180 degrees
            isFlippedLeft = false;
        } 
        else if (aimDirection.x > 0 && !isFlippedLeft)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); // Flip player to Right
            firePoint.localRotation = Quaternion.Euler(0, 0, 0); // Reset firePoint rotation
            isFlippedLeft = true;
        }
    }

    void OnShoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}


