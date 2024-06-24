using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplitScreenManager : MonoBehaviour
{
    public GameObject playerPrefab1; // Reference to the prefab of the player GameObject
    public GameObject playerPrefab2; // Reference to the prefab of the player GameObject
    public Transform spawnPoint1; // Spawn point where players will be instantiated
    public Transform spawnPoint2; // Spawn point where players will be instantiated

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate player prefab at the next spawn point in the array
        GameObject newPlayer1 = Instantiate(playerPrefab1, spawnPoint1.position, Quaternion.identity);
        GameObject newPlayer2 = Instantiate(playerPrefab1, spawnPoint2.position, Quaternion.identity);

        // Activate the instantiated player
        newPlayer1.SetActive(true);
        newPlayer2.SetActive(true);

    }

}
  