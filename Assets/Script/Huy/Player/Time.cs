using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
  
    public float timeRemaining = 10f; // Thời gian ban đầu
    private float initialTime; // Để lưu trữ giá trị thời gian ban đầu
    public static bool timerIsRunning = false;
    public TMP_Text timeText;

    public static bool TimeOver = false;

    void Start()
    {
        // Lưu trữ thời gian ban đầu
        initialTime = timeRemaining;
        DisplayTime(timeRemaining); // Hiển thị thời gian ban đầu khi khởi động
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Giảm thời gian còn lại
                timeRemaining -= Time.deltaTime;
                // Cập nhật UI hiển thị thời gian
                DisplayTime(timeRemaining);
            }
            else
            {
                // Khi thời gian kết thúc
                timeRemaining = 0;
                if (timeRemaining == 0)
                {
                    TimeOver = true;
                }
                //timerIsRunning = false;
                Debug.Log("Hết thời gian!");
            }
        }

        if (!timerIsRunning)
        {
            ResetTime();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Thêm 1 để làm tròn lên
        // Tính số giây
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Cập nhật văn bản UI với thời gian hiện tại
        timeText.text = seconds.ToString();
    }

    // Đặt lại thời gian về trạng thái ban đầu
    public void ResetTime()
    {
        TimeOver = false;
        timeRemaining = initialTime; // Đặt lại thời gian về thời gian ban đầu
        timerIsRunning = false; // Dừng bộ đếm thời gian
        DisplayTime(timeRemaining); // Cập nhật UI với thời gian đã được đặt lại
        Debug.Log("Bộ đếm thời gian đã được đặt lại!");
    }
}
