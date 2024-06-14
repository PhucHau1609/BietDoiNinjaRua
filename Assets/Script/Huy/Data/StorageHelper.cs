using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class StorageHelper : MonoBehaviour
{
    private readonly string filename = "gameData.txt";
    public GameDataPlayed played;

    public void LoadData()
    {

        played = new GameDataPlayed()
        {
            plays = new List<GameData>()
        };
        // doc chuoi tu file
        string dataAsJson = StorageManager.LoadFromFile(filename);
        if (dataAsJson != null)
        {
            played = JsonUtility.FromJson<GameDataPlayed>(dataAsJson);
        }
    }

    public void SaveData()
    {
        string dataAsJson = JsonUtility.ToJson(played);
        StorageManager.SaveToFile(filename, dataAsJson);
    }
}
