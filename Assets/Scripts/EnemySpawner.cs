using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>(); // Assign this in the inspector

    [SerializeField] float initialSpawnRate = 5f;
    [SerializeField] float secondSpawnRate = 2f;
    [SerializeField] float thirdSpawnRate = 1f;
    [SerializeField] float fourthSpawnRate = .5f;


    [SerializeField] float spawnRate = 5f;
    public Vector2[] spawnLocations;
    public int maxEnemies = 50;
    private float y = 2f;
    private float minX = -20f;
    private float maxX = 20f;

    private float nextSpawnTime;
    private List<GameObject> enemies = new List<GameObject>();
    private int enemyPrefabsIndex = 0;

    private void Start()
    {
        maxEnemies = KillBudget.instance.initialKillBudget;
    }

    private void Update()
    {
        if (KillBudget.instance.currKillBudget <= 0)
        {
            // If kill budget is 0, stop spawning enemies

            // To do: Remove temporary win condition when Boss is implemented
            if (enemies.Count == 0)
            {
                SceneChanger.instance.LoadWinScene();
            }
        }
        else
        {
            // Check if it's time to spawn an enemy
            if (Time.time >= nextSpawnTime && enemies.Count < maxEnemies)
            {
                nextSpawnTime = Time.time + spawnRate;
                Vector2 spawnLocation = new Vector2(Random.Range(minX, maxX), y);
                SpawnEnemy(GetNextEnemyPrefab(), spawnLocation);
                enemyPrefabsIndex++;
                IncreaseSpawnRate();
            }

            // Cleanup any null entries if enemies were destroyed
        }
        enemies.RemoveAll(item => item == null);
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector2 spawnLocation)
    {
        Debug.Log("enemyspawner.cs -> enemies spawned: " + enemies.Count + " --- spawn rate: " + spawnRate);
        var newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        enemies.Add(newEnemy);
    }

    private GameObject GetNextEnemyPrefab()
    {
        if (enemyPrefabsIndex == enemyPrefabs.Count) enemyPrefabsIndex = 0;
        return enemyPrefabs[enemyPrefabsIndex];
    }

    private void IncreaseSpawnRate()
    {
        if (KillBudget.instance.currKillBudget < ((KillBudget.instance.initialKillBudget / 4) * .4)) spawnRate = thirdSpawnRate;
        else if (KillBudget.instance.currKillBudget < ((KillBudget.instance.initialKillBudget / 4) * 1)) spawnRate = fourthSpawnRate;
        else if (KillBudget.instance.currKillBudget < ((KillBudget.instance.initialKillBudget / 4) * 2)) spawnRate = thirdSpawnRate;
        else if (KillBudget.instance.currKillBudget < ((KillBudget.instance.initialKillBudget / 4) * 3)) spawnRate = secondSpawnRate;
        else spawnRate = initialSpawnRate;
    }
}
