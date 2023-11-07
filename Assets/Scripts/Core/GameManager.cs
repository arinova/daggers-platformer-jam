using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isBossFight { get; private set; }
    public delegate void OnBossFightTriggered();
    public OnBossFightTriggered OnBossFightTriggeredCallback;

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
        if (OnBossFightTriggeredCallback != null)
        {
            OnBossFightTriggeredCallback.Invoke();
        }
    }
}
