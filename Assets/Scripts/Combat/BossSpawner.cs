using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;

    void Start()
    {
        GameManager.instance.OnBossFightTriggeredCallback += SpawnBoss;
    }

    public void SpawnBoss()
    {
        var newEnemy = Instantiate(bossPrefab, gameObject.transform.position, Quaternion.identity);
        newEnemy.gameObject.GetComponent<Enemy>().setIsBossTrue();
    }
}