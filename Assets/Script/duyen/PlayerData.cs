using UnityEngine;
using System.Collections.Generic;

public class Player
{
    public string playerName;
    public int playerScore;
}

public class PlayerData : MonoBehaviour
{
    // Danh sách người chơi
    List<Player> players = new List<Player>();

    void Start()
    {
        // Load danh sách người chơi từ PlayerPrefs
        LoadPlayers();
    }

    void SavePlayers()
    {
        // Chuyển danh sách người chơi thành chuỗi JSON
        string json = JsonUtility.ToJson(players);

        // Lưu chuỗi JSON vào PlayerPrefs
        PlayerPrefs.SetString("PlayerList", json);
        PlayerPrefs.Save();
    }

    void LoadPlayers()
    {
        // Đọc chuỗi JSON từ PlayerPrefs
        string json = PlayerPrefs.GetString("PlayerList");

        // Nếu chuỗi không rỗng
        if (!string.IsNullOrEmpty(json))
        {
            // Chuyển chuỗi JSON thành danh sách người chơi
            players = JsonUtility.FromJson<List<Player>>(json);
        }
    }

    void AddPlayer(string name, int score)
    {
        // Tạo một đối tượng Player mới
        Player newPlayer = new Player();
        newPlayer.playerName = name;
        newPlayer.playerScore = score;

        // Thêm người chơi vào danh sách
        players.Add(newPlayer);

        // Lưu lại danh sách sau khi thêm
        SavePlayers();
    }

    void RemovePlayer(string name)
    {
        // Tìm và loại bỏ người chơi từ danh sách
        players.RemoveAll(player => player.playerName == name);

        // Lưu lại danh sách sau khi loại bỏ
        SavePlayers();
    }
}
