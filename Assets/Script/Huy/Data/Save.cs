using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;


public class Save : Singleton<Save>
{
    private StorageHelper storageHelper;
    private GameDataPlayed played;

    private void Start()
    {
        storageHelper = new StorageHelper();
        storageHelper.LoadData();
        played = storageHelper.played;
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
}
