using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private CharacterController characterController;
    Vector2 moveInput;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
            Debug.LogError("CharacterController component not found!");
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(moveInput.x, moveInput.y);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
