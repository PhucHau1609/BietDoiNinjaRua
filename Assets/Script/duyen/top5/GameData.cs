using System.Collections.Generic;

[System.Serializable]
public class gamedata
{
    public int Coint = 0;
    public string timePlayer;
}

[System.Serializable]
public class gamedataplay
{
    public List<gamedata> plays;
}
