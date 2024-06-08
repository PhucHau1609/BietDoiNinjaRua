using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor;
using System.Data;
using Unity.Collections;
using System;

public class Finish : MonoBehaviour
{
    private StorageHelper storageHelper;
    private gamedataplay played;
    void Start()
    {
        storageHelper = new StorageHelper();
        storageHelper.LoadData();
        played = storageHelper.played;
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            var Coint = FindObjectOfType<GameManager>().GetCoint();
            
            var game_data = new gamedata(){
                
                Coint = Coint,
                timePlayer = DateTime.Now.ToString(format:"dd-MM-yyy HH:mm:ss")
            };
            played.plays.Add(game_data);
            storageHelper.SaveData();
            storageHelper.LoadData();
            played = storageHelper.played;
            Debug.Log("Count: " + played.plays.Count);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
