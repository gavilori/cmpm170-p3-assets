using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float totalTime = 30f; // Set the initial total time in seconds
    private float currentTime;
    private TextMeshProUGUI timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            if (!GameManager.gameOver)
            {
                GameManager.gameOver = true;
            }
        }
        if (GameManager.gameOver)
        {
            gameObject.SetActive(false);
        }
    }

    void UpdateTimerDisplay()
    {
        // Format the time as minutes:seconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the TextMeshPro text
        timerText.text = timerString;
    }
}
