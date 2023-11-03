using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    // Can be moved to a weapon class
    void SpawnAttackPrefab()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    public void TriggerFire()
    {
        SpawnAttackPrefab();
    }
}
