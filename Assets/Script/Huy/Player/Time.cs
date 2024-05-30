using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Thời gian bắt đầu, ví dụ 60 giây
    public bool timerIsRunning = false; // Trạng thái của timer
    public TMP_Text timeText; // Text để hiển thị thời gian

    void Start()
    {
        // Bắt đầu bộ đếm thời gian khi bắt đầu game
        timerIsRunning = true;
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
                timerIsRunning = false;
                Debug.Log("Time has run out!");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Thêm 1 để làm tròn lên
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Tính số phút
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Tính số giây

        // Cập nhật Text hiển thị
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}