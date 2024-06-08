using System.Collections.Generic;
using UnityEngine;

public class StorageHelper
{
    private readonly string filename = "game_data.txt";
    public gamedataplay played;

    public void LoadData()
    {
        string dataAsJson = StorageManager.LoadFromFile(filename);
        if (dataAsJson != null)
        {
            played = JsonUtility.FromJson<gamedataplay>(dataAsJson);
        }
        else
        {
            Debug.LogWarning("Không thể tải dữ liệu từ tệp " + filename + ". Tạo một bảng chơi mới.");
            played = new gamedataplay
            {
                plays = new List<gamedata>()
            };
        }
    }

    public void SaveData()
    {
        string dataAsJson = JsonUtility.ToJson(played);
        if (dataAsJson != null)
        {
            StorageManager.SaveToFile(filename, dataAsJson);
        }
        else
        {
            Debug.LogError("Không thể lưu dữ liệu vào tệp " + filename);
        }
    }
}
