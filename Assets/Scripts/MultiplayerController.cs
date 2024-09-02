using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MultiplayerController : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Reference to the prefab of the player GameObject
    public Transform[] spawnPoints; // Spawn point where players will be instantiated
    public int totalPlayers; // Reference to the total number of players that must be spawned.
    public CinemachineTargetGroup cinemachineTargetGroup; // Reference to the Cinemacine Target Group object.

    [SerializeField] float cinemachineWeight;
    [SerializeField] float cinemachineRadius;
     
    // Start is called before the first frame update
    void Start()
    {
        // Ensure totalPlayers is within the valid range starting.
        totalPlayers = Mathf.Clamp(totalPlayers, 1, 4);

        CreatePlayers();
    }


    private void CreatePlayers()
    {
        // Loop to instantiate the player prefabs at the spawn points.
        for (int i = 0; i < totalPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefabs[i], spawnPoints[i].position, Quaternion.identity);

            // Add the instantiated player to the Cinemachine target group.
            cinemachineTargetGroup.AddMember(player.transform, cinemachineWeight, cinemachineRadius);
        }
    }

}
