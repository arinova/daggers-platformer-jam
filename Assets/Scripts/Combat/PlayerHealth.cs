using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float Health { get; set; }
    [SerializeField] public int maxHealth = 5;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;   
    }

    void Update()
    {
        CheckPlayerFallOffLevel();
    }

    public void Damage(float amount)
    {
        Debug.Log("PlayerHealth: Player Damaged");
        if (GameManager.instance.isBossFight)
        {
            Health -= amount;

            if (Health <= 0)
            {
                Die();
            }
        }
        else
        {
            KillBudget.instance.DecrementKillBudget(1);
        }
    }

    void Die()
    {
        SceneChanger.instance.LoadGameOverScene();
    }

    void CheckPlayerFallOffLevel()
    {
        if (Player.transform.position.y <= -8)
        {
            Die();
        }
    }
}
