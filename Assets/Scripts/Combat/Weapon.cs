using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float attackCooldownTimer = 0;
    [SerializeField] private float attackCooldown = 1f; // .1f is fast, make larger to slow down fire rate
    private bool weaponTriggered = false;
    private float minAttackCooldown = .1f; // .1f is fast, make larger to slow down fire rate

    // Bullet
    [SerializeField] private float bulletSpeed = 10f; // 5-20 (increasing speed also increases range because it travels faster before timer destroys it)
    private float maxBulletSpeed = 20f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        attackCooldownTimer += Time.deltaTime / attackCooldown;
        if (attackCooldownTimer >= 1 && weaponTriggered)
        {
            attackCooldownTimer = 0;
            weaponTriggered = false;
            SpawnAttackPrefab();
        }
    }

    // Can be moved to a weapon class
    void SpawnAttackPrefab()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.gameObject.GetComponent<Bullet>().SetBulletSpeed(bulletSpeed);
    }

    public void TriggerFire()
    {
        weaponTriggered = true;
    }

    public void IncreaseBulletSpeed(float amount)
    {
        if (bulletSpeed < maxBulletSpeed) bulletSpeed += amount;
    }

    public void IncreaseFireRate(float amount)
    {
        if (bulletSpeed > minAttackCooldown) attackCooldown -= amount;
    }
}