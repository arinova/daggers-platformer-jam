using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public GameObject prefabToRespawn; // The prefab you want to respawn
    public float respawnTime = 5f; // Time in seconds after which the prefab will respawn
    public string prefabTag = "RespawnablePrefab";
    public float Health { get; set; }
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        while (true) // Infinite loop to keep checking for respawn
        {
            yield return new WaitForSeconds(respawnTime); // Wait for the specified time

            // Check if there is already a prefab in the scene
            GameObject existingPrefab = GameObject.FindWithTag(prefabTag);
            if (existingPrefab == null) // If there is no prefab, instantiate a new one
            {
                Instantiate(prefabToRespawn, transform.position, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float amount)
    {
        Debug.Log("enemy.cs -> damage, " + Health);
        Health -= amount;

        if (Health <= 0)
        {
            if (alive) Die();
        }
    }

    void Die()
    {
        alive = false;
        KillBudget.instance.DecrementKillBudget(1);
        Destroy(gameObject);
    }
}
