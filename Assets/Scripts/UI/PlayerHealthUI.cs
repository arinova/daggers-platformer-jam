using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] Image healthBarSprite;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUIText();
        UpdateFillSprite();
    }

    void UpdateHealthUIText()
    {
        playerHealthText.text = playerHealth.Health.ToString();
    }

    void UpdateFillSprite()
    {
        healthBarSprite.fillAmount = playerHealth.Health / playerHealth.maxHealth;
    }
}
