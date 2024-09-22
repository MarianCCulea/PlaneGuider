using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component
    private float timeRemaining = 60f;  // 60 seconds countdown
    private bool timerIsRunning = false;  // Tracks if the timer is running
    
    public GameObject winningPanel;


    void Start()
    {
        // Start the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Decrease time and update the timer UI
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // If the timer hits 0, stop the countdown
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
                winningPanel.SetActive(true);
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        // Ensure the time is never negative
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);

        // Format the time as whole seconds
        float seconds = Mathf.FloorToInt(timeToDisplay);

        // Display the time in the TextMeshProUGUI component
        timerText.text = string.Format("{0:00} s", seconds);
    }
}