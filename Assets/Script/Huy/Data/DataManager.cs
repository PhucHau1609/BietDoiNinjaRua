using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;

public class DataManager : Singleton<DataManager>
{
    private StorageHelper storageHelper;
    private GameDataPlayed played;

    [SerializeField] GameObject row;

    private void Start()
    {
        storageHelper = new StorageHelper();
        storageHelper.LoadData();
        played = storageHelper.played;
        LoadDataGamePlayed();
    }

    public void AddGamePlayed()
    {
        var gameData = new GameData()
        {
            NamePlayer = GameManager.Instance.GetName(),
            Score = GameManager.Instance.GetCoint(),
            TimePlayed = ClockController.currentTime,
            DatePlayed = ClockController.currentDate
            
        };
        played.plays.Add(gameData);
        storageHelper.SaveData();
    }

    public void LoadDataGamePlayed()
    {
        //storageHelper = new StorageHelper();
        //storageHelper.LoadData();
        //played = storageHelper.played;

        for (int i = 0; i < played.plays.Count; i++)
        {
            Debug.Log("Name: " + played.plays[i].NamePlayer
                + "| Score: " + played.plays[i].Score
                + "| TimePlayed: " + played.plays[i].TimePlayed
                + "| DatePlayed: " + played.plays[i].DatePlayed);
        }

        played.plays.Sort((x,y)=> y.Score.CompareTo(x.Score));
        var plays = played.plays.GetRange(0, Math.Min(5, played.plays.Count));

        for (int i = 0; i < plays.Count; i++)
        {
            var rowInstance = Instantiate(row, row.transform.parent);
            rowInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            rowInstance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = plays[i].NamePlayer.ToString();
            rowInstance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = plays[i].Score.ToString();
            rowInstance.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = plays[i].TimePlayed.ToString();
            rowInstance.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = plays[i].DatePlayed.ToString();
            rowInstance.SetActive(true);
        }
    }

}
