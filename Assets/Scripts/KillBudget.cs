using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBudget : MonoBehaviour
{
    public static KillBudget instance;

    public int initialKillBudget;
    public int maxKillBudget;
    public int currKillBudget { get; private set; }

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
        currKillBudget = initialKillBudget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementKillBudget(int amount)
    {
        currKillBudget += amount;

        if (currKillBudget > maxKillBudget)
        {
            currKillBudget = maxKillBudget;
        }
    }

    public void DecrementKillBudget(int amount)
    {
        currKillBudget -= amount;

        if (currKillBudget <= 0)
        {
            currKillBudget = 0;
            // To Do: Trigger Boss Fight
            GameManager.instance.TriggerBossFight();
        }
    }
}
