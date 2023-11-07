using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class TimeTrialManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // Reference to your TextMeshProUGUI component
    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00.00");
            timeText.text = minutes + ":" + seconds;
        }

        if (KillBudget.instance.currKillBudget == 0) {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
