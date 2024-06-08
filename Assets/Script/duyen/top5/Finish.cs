using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private StorageHelper storageHelper;
    private gamedataplay played;

    void Start()
{
    storageHelper = new StorageHelper();
    storageHelper.LoadData();
    
    // Kiểm tra xem dữ liệu đã được tải thành công không
    if (storageHelper.played != null)
    {
        played = storageHelper.played;
    }
    else
    {
        Debug.LogWarning("Không thể tải dữ liệu từ StorageHelper.");
    }
}


    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            var Coint = gameManager.GetCoint(); // Fix NullReferenceException here
            
            if (played != null && played.plays != null)
            {
                var game_data = new gamedata()
                {
                    Coint = Coint,
                    timePlayer = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") // Corrected the format
                };
                played.plays.Add(game_data);
                // storageHelper.SaveData();
                // storageHelper.LoadData();
                // played = storageHelper.played;
                Debug.Log("Count: " + played.plays.Count);
            }
            else
            {
                Debug.LogWarning("Played or played.plays is null.");
            }
        }
        else
        {
            Debug.LogWarning("GameManager not found in the scene.");
        }
    }
}


    // Update is called once per frame
    void Update()
    {
        // Any update logic you might have
    }
}
