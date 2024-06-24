using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public GameObject playerPrefab1; // Reference to the prefab of the player GameObject
    public GameObject playerPrefab2; // Reference to the prefab of the player GameObject
    public GameObject playerPrefab3; // Reference to the prefab of the player GameObject
    public GameObject playerPrefab4; // Reference to the prefab of the player GameObject
    public Transform spawnPoint1; // Spawn point where players will be instantiated
    public Transform spawnPoint2; // Spawn point where players will be instantiated
    public Transform spawnPoint3; // Spawn point where players will be instantiated
    public Transform spawnPoint4; // Spawn point where players will be instantiated

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MultiplayerController script started");
        // Instantiate player prefab at the next spawn point in the array
        GameObject newPlayer1 = Instantiate(playerPrefab1, spawnPoint1.position, Quaternion.identity);
        GameObject newPlayer2 = Instantiate(playerPrefab2, spawnPoint2.position, Quaternion.identity);
        GameObject newPlayer3 = Instantiate(playerPrefab3, spawnPoint3.position, Quaternion.identity);
        GameObject newPlayer4 = Instantiate(playerPrefab4, spawnPoint4.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
