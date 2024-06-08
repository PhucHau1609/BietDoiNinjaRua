using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class gamedata
{
    public string Usename;
    public int Coint = 0;
    public string timePlayer;
}
[SerializeField]
public class gamedataplay{
    public List<gamedata> plays;
}
