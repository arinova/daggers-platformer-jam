using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign this in the inspector
    public float spawnRate = 0.02f;
    public Vector2[] spawnLocations;
    public int maxEnemies = 100;
    private float y = 2f;
    private float minX = -20f;
    private float maxX = 20f;

    private float nextSpawnTime;
    private List<GameObject> enemies = new List<GameObject>();

    private void Update()
    {
        // Check if it's time to spawn an enemy
        if (Time.time >= nextSpawnTime && enemies.Count < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
            Vector2 spawnLocation = new Vector2(Random.Range(minX, maxX), y);
            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }

        // Cleanup any null entries if enemies were destroyed
        enemies.RemoveAll(item => item == null);
    }

    private void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemies.Add(newEnemy);
    }
}
