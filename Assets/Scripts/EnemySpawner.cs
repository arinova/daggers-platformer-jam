using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>(); // Assign this in the inspector
    public float spawnRate = 5f;
    public Vector2[] spawnLocations;
    public int maxEnemies = 100;
    private float y = 2f;
    private float minX = -20f;
    private float maxX = 20f;

    private float nextSpawnTime;
    private List<GameObject> enemies = new List<GameObject>();
    private int enemyPrefabsIndex = 0;

    private void Update()
    {
        // Check if it's time to spawn an enemy
        if (Time.time >= nextSpawnTime && enemies.Count < maxEnemies)
        {
            nextSpawnTime = Time.time + spawnRate;
            Vector2 spawnLocation = new Vector2(Random.Range(minX, maxX), y);
            SpawnEnemy(GetNextEnemyPrefab(), spawnLocation);
            enemyPrefabsIndex++;
        }

        // Cleanup any null entries if enemies were destroyed
        enemies.RemoveAll(item => item == null);
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector2 spawnLocation)
    {
        var newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        enemies.Add(newEnemy);
    }

    private GameObject GetNextEnemyPrefab()
    {
        if (enemyPrefabsIndex == enemyPrefabs.Count) enemyPrefabsIndex = 0;
        return enemyPrefabs[enemyPrefabsIndex];
    }
}
