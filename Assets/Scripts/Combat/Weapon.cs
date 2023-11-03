using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float attackCooldownTimer = 0;
    [SerializeField] private float attackCooldown = 1;

    // Can be moved to a weapon class
    void SpawnAttackPrefab()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    public void TriggerFire()
    {
        
        attackCooldownTimer += Time.deltaTime / attackCooldown;
        if (attackCooldownTimer >= 1)
        {
            attackCooldownTimer -= 1;
            SpawnAttackPrefab();
        }
    }
}