using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;

public class GameManager : Singleton<GameManager>
{
    public int Coint;
    public int Heart;

    private void Start()
    {
        ResetCointAndHeart();
    }

    public int GetCoint()
    { 
        return Coint;
    }

    public int GetHeart()
    {
        return Heart;
    }

    public void ResetCointAndHeart()
    {
        Coint = 0;
        Heart = 3;
    }

    public void SetCoint(int value)
    {
        Coint += value;
    }

    public void SetHeart(int value)
    {
        Heart = value;
    }

}
