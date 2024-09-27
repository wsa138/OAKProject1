using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAssignmentHandling : MonoBehaviour
{
    private PlayerInput playerInput;
    private int playerIndex;
    private GameObject playerNumberText;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to player input and player index number.
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex + 1;
        Debug.Log("this is player " + playerIndex);

        SetPlayerControllerNumber();
    }

    //FIX: Clean Up
    private void SetPlayerControllerNumber()
    {
        Transform playerControllerNumber = transform.Find("PlayerControllerNumber");

        if (playerControllerNumber != null)
        {
            playerNumberText = playerControllerNumber.Find("P" + playerIndex).gameObject;
        }
        else
        {
            Debug.LogWarning("playerControllerNumber object not found.");
        }

        // Check if playerText was found
        if (playerNumberText != null)
        {
            playerNumberText.SetActive(true);
        }
        else
        {
            Debug.LogWarning("P1 TextMeshPro object not found.");
        }
    }
}
