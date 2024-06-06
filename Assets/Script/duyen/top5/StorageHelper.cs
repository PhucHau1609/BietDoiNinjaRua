using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHelper
{
    private readonly string filename = "game_data.txt";
    public GameDataPlayed played;
    public void LoadData(){
        played = new GameDataPlayed(){
            plays = new List<GameData>()
        };
        //doc chuoi tu file
        string dataAsJson = StorageManager.LoadFromFile(filename);
        if (dataAsJson != null){
            //chuyen chuoi json thanh object
            played = JsonUtility.FromJson<GameDataPlayed>(dataAsJson);
        }
    }
    //luu du lieu lai
    public void SaveData(){
        //chuyen object thanh chuoi json
        string dataAsJson = JsonUtility.ToJson(played);
        //luu chuoi json vao file
        StorageManager.SaveToFile(filename,dataAsJson);
    }
}

