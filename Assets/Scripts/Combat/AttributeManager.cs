using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    public static AttributeManager instance;
    private Dictionary<Attribute, int> attributeKillCount = new Dictionary<Attribute, int>();
    private int killsToUpdate = 25;

    // Amount an attribute changes per upgrade
    private float fireRateInc = .25f;
    private float bulletSpeedInc = 2.5f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeAttributeKillDictionary();
        killsToUpdate = KillBudget.instance.initialKillBudget / 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKills(Attribute attribute, int level)
    {
        attributeKillCount[attribute] += 1 * level;
        Debug.Log("attributemanager.cs -> " + attribute + " killed: " + attributeKillCount[attribute].ToString());
        CheckAttributeUpdate(attribute);
    }

    private void CheckAttributeUpdate(Attribute attribute)
    {

        if (attributeKillCount[attribute] >= killsToUpdate)
        {
            Debug.Log("attributemanager.cs -> " + killsToUpdate + " kills - upgrading " + attribute.ToString());
            UpdateAttribute(attribute);
            attributeKillCount[attribute] = attributeKillCount[attribute] - killsToUpdate;
        }
    }

    private void UpdateAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.BULLET_SPEED:
                Weapon.instance.IncreaseBulletSpeed(bulletSpeedInc);
                break;
            case Attribute.FIRE_RATE:
                Weapon.instance.IncreaseFireRate(fireRateInc);
                break;
            default: break;
        }
    }

    private void InitializeAttributeKillDictionary()
    {
       foreach (Attribute attr in Enum.GetValues(typeof(Attribute)))
       {
            attributeKillCount.Add(attr, 0);
       }
    }
}

public enum Attribute
{
    BULLET_SPEED = 0,
    FIRE_RATE = 1
}