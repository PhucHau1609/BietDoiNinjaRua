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

    [SerializeField]
    public int HeartStart = 100;
    private int Heart;
    private int Coint;

    private void Update()
    {
        Debug.Log("Heart: " + Heart);
    }

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
        Heart = HeartStart;
    }

    public void SetCoint(int value)
    {
        Coint += value;
    }

    public void ReceiveDamage(int damage)
    {
        Heart -= damage;
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
