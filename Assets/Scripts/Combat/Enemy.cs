using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public float Health { get; set; }
    public float speed = 3;
    [SerializeField] public int maxHealth = 1;
    [SerializeField] private bool alive = true;
    [SerializeField] Attribute attributeType = Attribute.BULLET_SPEED;
    [SerializeField] int level = 1; // 1, 2, 3 being easy, medium, hard with matching reward
    private bool isBoss = false;

    // Start is called before the first frame update
    private void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            if (alive) Die();
        }
    }

    void Die()
    {
        alive = false;
        if (!isBoss)
        {
            KillBudget.instance.DecrementKillBudget(1);
            AttributeManager.instance.UpdateKills(attributeType, level);
            Destroy(gameObject);
        }
        else
        {
            alive = false;

            // To Do: Win Screen
            Destroy(gameObject);
        }
    }

    public bool IsAlive()
    {
        return alive;
    }

    public void setIsBossTrue()
    {
        isBoss = true;
    }
}