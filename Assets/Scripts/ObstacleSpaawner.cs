using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpaawner : MonoBehaviour
{
    [SerializeField]private GameObject[] obstaclePrefab;
    private GameObject lastSpawnedObstacle;
   // [SerializeField]private float minXOffset;
    //[SerializeField] private float maxXOffset;

    [SerializeField] private float spawnInterval = 2f; // Interval in seconds
    [SerializeField] private Transform playerTransform;

    private float lastSpawnZ = 0f;
    private float spawnGap = 20f; // 5-meter gap between obstacles

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (lastSpawnedObstacle==null)
            {
                TrySpawnObstacle();
            }
                yield return new WaitForSeconds(spawnInterval);
            
        }
    }
    void TrySpawnObstacle()
    {
        float spawnZ = playerTransform.position.z + 30; // Spawning 30 units in front of the player
        if (spawnZ - lastSpawnZ >= spawnGap)
        {
            SpawnObstacle(spawnZ);
        }
    }

    void SpawnObstacle(float spawnZ)
    {
        float spawnX = Random.Range(playerTransform.position.x  , playerTransform.position.x);
        Vector3 spawnPosition = new Vector3(spawnX, playerTransform.position.y, spawnZ);
        int randomIndex=Random.Range(0, obstaclePrefab.Length);
        lastSpawnedObstacle = Instantiate(obstaclePrefab[randomIndex], spawnPosition, Quaternion.identity);
        lastSpawnZ = spawnZ; // Update the last spawn position
       // spawnCheck = false;
    }
}
