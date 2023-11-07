using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    private bool bossSpawned = false;

    void Start()
    {
        GameManager.instance.OnBossFightTriggeredCallback += SpawnBoss;
    }

    public void SpawnBoss()
    {
        if (!bossSpawned)
        {
            var newEnemy = Instantiate(bossPrefab, gameObject.transform.position, Quaternion.identity);
            newEnemy.gameObject.GetComponent<Enemy>().setIsBossTrue();
            bossSpawned = true;
        }
    }
}