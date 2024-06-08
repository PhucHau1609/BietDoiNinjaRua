using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private StorageHelper storageHelper;
    private gamedataplay played;
    [SerializeField] GameObject row;

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
                storageHelper.SaveData();
                storageHelper.LoadData();
                played = storageHelper.played;
                Debug.Log("Count: " + played.plays.Count);
                //xx
            played.plays.Sort((x,y) => y.Coint.CompareTo(x.Coint));
            var plays = played.plays.GetRange(0,Math.Min(5, played.plays.Count));
            //loadbar
            for (int i = 0; 1 < plays.Count; i++)
            {
                var rowInstance = Instantiate(row, row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].Coint.ToString();
                rowInstance.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].timePlayer;
                rowInstance.SetActive(true);
                Destroy(gameObject);
            }
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
