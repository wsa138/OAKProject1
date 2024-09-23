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

    private List<GameObject> playersList = new List<GameObject>(); // List to store instantiated players

    [SerializeField] float cinemachineWeight;
    [SerializeField] float cinemachineRadius;
     
    // Start is called before the first frame update
    void Start()
    {
        // Ensure totalPlayers is within the valid range starting.
        totalPlayers = Mathf.Clamp(totalPlayers, 1, 4);

        CreatePlayers();

        //TEST: Multiplayer test area
        LogPlayers();
        StartCoroutine(KillPlayers());
    }


    private void CreatePlayers()
    {
        // Loop to instantiate the player prefabs at the spawn points.
        for (int i = 0; i < totalPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefabs[i], spawnPoints[i].position, Quaternion.identity);

            // Add the instantiated player to the players list
            playersList.Add(player);

            // Add the instantiated player to the Cinemachine target group.
            cinemachineTargetGroup.AddMember(player.transform, cinemachineWeight, cinemachineRadius);
        }
    }


    //TEST: Multiplayer Test Area

    // Log Players
    private void LogPlayers()
    {
        for (int i = 0; i < playersList.Count; i++)
        {
            Debug.Log($"Player {i + 1} Transform: {playersList[i].transform.position}");
        }
    }

    // Kill each player after 5 seconds
    IEnumerator KillPlayers()
    {
        // Wait 5 seconds
        yield return new WaitForSeconds(5f);

        Debug.Log("Kill player 1");
        // Kill Player
        Destroy(playersList[0]);
    }
}
