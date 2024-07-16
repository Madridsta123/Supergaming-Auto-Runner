using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float leftXOffset;
    [SerializeField] private float rightXOffset;
    [SerializeField] private float spawnInterval = 2f; // Interval in seconds
    [SerializeField] private Transform playerTransform;

    //private GameObject lastSpawnedEnemy;
    private float lastSpawnZ = 0f;
    private float spawnGap = 30f; // 30-meter gap between enemies

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            TrySpawnEnemy();
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void TrySpawnEnemy()
    {
        float spawnZ = playerTransform.position.z + 100f; // Spawning 10 units in front of the player
        if (spawnZ - lastSpawnZ >= spawnGap)
        {
            SpawnEnemy(spawnZ);
        }
    }

    void SpawnEnemy(float spawnZ)
    {
        float spawnX;
        // Randomly choose to spawn left or right of the player
        if (Random.value < 0.5f)
        {
            spawnX = playerTransform.position.x + leftXOffset;
        }
        else
        {
            spawnX = playerTransform.position.x + rightXOffset;
        }
        Vector3 spawnPosition = new Vector3(spawnX, playerTransform.position.y, spawnZ);
        int RandomIndex = Random.Range(0, enemyPrefab.Length);
         Instantiate(enemyPrefab[RandomIndex], spawnPosition, Quaternion.identity);
        lastSpawnZ = spawnZ; // Update the last spawn position
    }
}
