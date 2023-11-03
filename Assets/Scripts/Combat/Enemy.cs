using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float Health { get; set; }
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
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
