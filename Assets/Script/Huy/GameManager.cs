using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map 1");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit Game...");
    }

}
