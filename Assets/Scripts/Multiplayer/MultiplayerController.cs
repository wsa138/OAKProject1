using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class MultiplayerController : MonoBehaviour
{
    public MultiplayerDataSO multiplayerData; // Access the MultiplayerData Scriptable Object for this project.
    public GameObject[] playerPrefabs; // Reference to the prefab of the player GameObject
    public Transform[] spawnPoints; // Spawn point where players will be instantiated
    public CinemachineTargetGroup cinemachineTargetGroup; // Reference to the Cinemacine Target Group object.

    private List<GameObject> playersList = new List<GameObject>(); // List to store instantiated players

    [SerializeField] float cinemachineWeight;
    [SerializeField] float cinemachineRadius;
     
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayers();

        //TEST: Multiplayer test area
        // LogPlayers();
        // CheckAssignedControllers();
        // StartCoroutine(KillPlayers());
        Debug.Log(multiplayerData.numberOfPlayers);
    }


    private void CreatePlayers()
    {
        // Loop to instantiate the player prefabs at the spawn points.
        for (int i = 0; i < multiplayerData.numberOfPlayers; i++)
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
        for (int i = 1; i < playersList.Count; i++)
        {
            Debug.Log($"Player {i + 1} Transform: {playersList[i].transform.position}");
        }
    }

    private void CheckAssignedControllers()
    {
        PlayerInput player1Input = playersList[0].GetComponent<PlayerInput>();
        Debug.Log(player1Input.devices[0].displayName);
    }

    // Kill each player after 5 seconds
    IEnumerator KillPlayers()
    {
        // Wait 5 seconds
        yield return new WaitForSeconds(2f);

        // Name gameobject
        playersList[0].name = "Player1";
        Debug.Log(playersList[0].name);

        // Kill Player
        Destroy(playersList[0]);
        playersList.RemoveAt(0);

        // List the number of player game objects remaining
        Debug.Log(playersList.Count);
    }
}
