using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillBudgetUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killBudgetText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKillBudgetUIText();
    }

    void UpdateKillBudgetUIText()
    {
        killBudgetText.text = "Kill Budget: " + KillBudget.instance.currKillBudget.ToString();
    }
}
