using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockController : Singleton<ClockController>
{
    public TMP_Text dateTimeTextShow;
    private float elapsedTime = 0f;
    private bool isRunning = false;
    private DateTime stopDateTime;

    public static string currentTime;
    public static string currentDate;

    void Start()
    {
        ResetTime();
        StartTime();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateDisplay();
        }
    }

    public void StartTime()
    {
        isRunning = true;
    }

    public void StopTime()
    {
        isRunning = false;
        stopDateTime = DateTime.Now;
    }

    public void ResetTime()
    {
        isRunning = false;
        elapsedTime = 0f;
        UpdateDisplay();
    }

    public DateTime GetStopDateTime()
    {
        return stopDateTime;
    }

    public void UpdateDisplay()
    {
        DateTime now = DateTime.Now;

        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        currentTime = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        currentDate = string.Format("{0:dd}/{0:MM}/{0:yyyy}", now);

        //dateTimeText.text = $"{currentDate} {currentTime}";
    }

}
