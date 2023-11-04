using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the prefab in the Inspector
    public Vector3 spawnPoint; // You can assign this dynamically if needed

    public void RespawnEnemy(GameObject enemyToRespawn, Vector3 spawnLocation)
    {
        StartCoroutine(RespawnCoroutine(enemyToRespawn, spawnLocation));
    }

    private IEnumerator RespawnCoroutine(GameObject enemyPrefab, Vector3 location)
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Now respawn the enemy
        Instantiate(enemyPrefab, location, Quaternion.identity);
    }
}

