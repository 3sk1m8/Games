using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;  //prefab of the ground

    public GameObject obstaclePrefab; // prefab of the obstacle
    public float spawnZ = 0;
    public float groundLength = 20;
    public int numberOfGrounds = 5;
    public float obstacleSpawnInterval = 3f; // Time interval for spawning obstacles
    // Start is called before the first frame update
   private void Start()
    {
       for (int i = 0; i < numberOfGrounds; i++)
       {
        SpawnGround();
       } 
       InvokeRepeating(nameof(SpawnObstacle), 1f, obstacleSpawnInterval);
    }

    // Update is called once per frame
    private  void  SpawnGround()
    {
      //Instantiate the ground prefab at the specified position and rotation
       Instantiate(groundPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
       spawnZ += groundLength; // Update the spawn position for the ground piece
    }
    private void SpawnObstacle()
    {
        float randomX = Random.Range(-3f, 3f); //Random X position for the obstacle
        Instantiate(obstaclePrefab, new Vector3(randomX, 0.5f, spawnZ),Quaternion.identity);
    }
}
