using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<GameObject> playerPrefabs; // List of player prefabs
    private List<GameObject> players = new List<GameObject>();
    private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        // Find all spawn points in the scene
        for (int i = 1; i <= 4; i++)
        {
            Transform spawnPoint = GameObject.Find($"Spawn{i}").transform;
            if (spawnPoint != null)
            {
                spawnPoints.Add(spawnPoint);
            }
        }

        // Register for the player joined event
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;

        // Manually join 4 players at the start
        for (int i = 0; i < 4; i++)
        {
            PlayerInputManager.instance.JoinPlayer(i);
        }
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        int playerIndex = playerInput.playerIndex;

        // Ensure only up to 4 players are spawned
        if (playerIndex >= 4)
        {
            Debug.LogWarning("More than 4 players are not supported.");
            return;
        }

        // Instantiate the appropriate player prefab based on the player index
        GameObject player = Instantiate(playerPrefabs[playerIndex % playerPrefabs.Count], spawnPoints[playerIndex % spawnPoints.Count].position, Quaternion.identity);

        // Activate the instantiated player
        player.SetActive(true);

        // Set the playerInput's gameObject to the instantiated player
        playerInput.gameObject.SetActive(true);
        playerInput.gameObject.transform.SetParent(player.transform, false);

        players.Add(player);

        // Set up the player's camera
        SetupPlayerCamera(playerInput);
    }

    private void SetupPlayerCamera(PlayerInput playerInput)
    {
        int playerIndex = playerInput.playerIndex;

        // Get the player's camera (assumes the camera is a child of the player)
        Camera playerCamera = playerInput.GetComponentInChildren<Camera>(true); // Find the disabled camera
        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(true); // Enable the camera

            // Ensure the camera is correctly positioned and oriented
            playerCamera.transform.localPosition = new Vector3(0, 0, -10);
            playerCamera.transform.localRotation = Quaternion.identity;

            // Set the camera's culling mask to include all layers or specific layers as needed
            playerCamera.cullingMask = LayerMask.GetMask("Default"); // Adjust this as needed

            // Configure the camera viewport based on player index
            Rect viewportRect = new Rect(0, 0, 1, 1);
            switch (playerIndex)
            {
                case 0:
                    viewportRect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    break;
                case 1:
                    viewportRect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                    break;
                case 2:
                    viewportRect = new Rect(0, 0, 0.5f, 0.5f);
                    break;
                case 3:
                    viewportRect = new Rect(0.5f, 0, 0.5f, 0.5f);
                    break;
            }
            playerCamera.rect = viewportRect;
        }
        else
        {
            Debug.LogError("Player has no camera associated with it. Cannot set up split-screen.");
        }
    }
}
