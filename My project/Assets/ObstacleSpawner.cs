using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 4f;
    public float spawnZPosition = 20f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }
    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZPosition);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

}
