using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData 
{
    public string NamePlayer;
    public int Score;
    public string TimePlayed;
    public string DatePlayed;
}

[Serializable]
public class GameDataPlayed
{
    public List<GameData> plays; 
}