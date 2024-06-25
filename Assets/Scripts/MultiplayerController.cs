using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Reference to the prefab of the player GameObject
    public Transform[] spawnPoints; // Spawn point where players will be instantiated
    public int totalPlayers; // Reference to the total number of players that must be spawned.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MultiplayerController script started");

        // Ensure totalPlayers is within the valid range starting.
        totalPlayers = Mathf.Clamp(totalPlayers, 1, 4);

        // Loop to instantiate the player prefabs at the spawn points.
        for (int i = 0; i < totalPlayers; i++)
        {
            Instantiate(playerPrefabs[i], spawnPoints[i].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
