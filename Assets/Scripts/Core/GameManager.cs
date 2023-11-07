using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isBossFight { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        isBossFight = false;
    }

    public void TriggerBossFight()
    {
        isBossFight = true;
        Debug.Log("GameManager: Boss Fight Triggered");

        // To Do: Trigger Boss Fight
    }
}
