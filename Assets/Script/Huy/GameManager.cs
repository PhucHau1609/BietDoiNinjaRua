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

    [SerializeField] int HeartStart = 100;
    [SerializeField] int LifeStart = 3;
    [SerializeField] int BuletStart = 10;
    private int Heart;
    private int Life;
    private int Coint;
    private int CountBulet;


    private void Update()
    {
    }

    private void Start()
    {
        Life = LifeStart;
        Reset();
    }

    public int GetCoint()
    { 
        return Coint;
    }

    public int GetHeart()
    {
        return Heart;
    }

    public int GetLife()
    {
        return Life;
    }

    public int GetCountBulet()
    {
        return CountBulet;
    }

    public void Reset()
    {
        Coint = 0;
        Heart = HeartStart;
        CountBulet = BuletStart;
    }

    public void ResetDie()
    {
        Coint = 0;
        Heart = HeartStart;
    }

    public void SetLifeCong(int value)
    {
        Life += value;
    }

    public void SetLifeTru(int value)
    {
        Life -= value;
    }

    public void SetCoint(int value)
    {
        Coint += value;
    }

    public void SetCountBuletCong(int value)
    {
        CountBulet += value;
    }

    public void SetCountBuletTru(int value)
    {
        CountBulet -= value;
    }

    public void ReceiveDamage(int damage)
    {
        Heart -= damage;
    }

    public void AddHeart(int value)
    {
        Heart += value;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map 1");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit Game...");
        SceneManager.LoadScene("Home");
    }

}
