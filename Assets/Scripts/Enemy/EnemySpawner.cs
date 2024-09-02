using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] Transform spawnPoint1;
     
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
    }
}
