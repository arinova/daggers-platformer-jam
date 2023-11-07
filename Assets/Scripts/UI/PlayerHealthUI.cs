using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUIText();
    }

    void UpdateHealthUIText()
    {
        if (KillBudget.instance.currKillBudget != 0)
        {
            playerHealthText.text = "Health: --";
        }
        else
        {
            playerHealthText.text = "Health: " + playerHealth.Health.ToString();
        }
    }
}
