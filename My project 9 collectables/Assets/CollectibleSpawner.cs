using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 2f;
    public Vector3 spawnArea = new Vector3(10, 1, 10);
    // Start is called before the first frame update
   private void Start()
    {
       InvokeRepeating("SpawnCollectible", 0f, spawnInterval); 
    }
    private void SpawnCollectable()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnArea.y,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
    }

    
}
