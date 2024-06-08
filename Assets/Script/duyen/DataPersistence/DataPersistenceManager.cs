using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    private List<DataPersistence> dataPersistencesObjects;
    public static DataPersistenceManager instance {get; private set;}
    private void Awake(){
        if(instance != null){
            Debug.LogError("Found more than one Data Persistence manager in the scene.");
        }
        instance = this;
    }
    private void Start(){
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        if(this.gameData == null){
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        foreach ( DataPersistence dataPersistenceObj in dataPersistencesObjects){
            dataPersistenceObj.LoadGame(gameData);
        }
        Debug.Log("Loaded death count = " + gameData.deathCount);
    }
    public void SaveGame(){
        foreach (DataPersistence dataPersistenceObj in dataPersistencesObjects){
            dataPersistenceObj.SaveGame(ref gameData);
        }
        Debug.Log("Saved death count = " + gameData.deathCount);
    }
    private void OnApplicationQuit(){
    SaveGame();
    }
    private List<DataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<DataPersistence> dataPersistencesObjects = 
        FindObjectsOfType<MonoBehaviour>().OfType<DataPersistence>();
        return new List<DataPersistence>(dataPersistencesObjects);

    }
}
