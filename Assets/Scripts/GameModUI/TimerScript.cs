using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float totalTime = 300f;
    private float currentTime = 0f;
    private bool isTimerRunning = false;

    public TMP_Text timerText;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                StopTimer();
                SceneManager.LoadScene("Endgame");
                Debug.Log("Temps écoulé !");
            }
            else
            {
                UpdateTimerDisplay();

            }
        }
    }

    public void StartTimer()
    {
        currentTime = totalTime;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public float GetTimeRemaining()
    {
        return currentTime;
    }

    void UpdateTimerDisplay()
    {
        int minutes = 0;
        int seconds = 0;

        if (timerText != null)
        {
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
