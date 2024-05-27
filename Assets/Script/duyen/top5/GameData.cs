using System;
using System.Collections.Generic;

[Serializable]
public class GameData{
    //luu thong tin game
    public int coin = 0;
    public string timePlayed;
    public string name ; 
}
//nhung lan choi
[Serializable]
public class GameDataPlayed{
    public List<GameData>plays;
}
