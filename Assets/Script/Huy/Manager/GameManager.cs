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

    private string Name;
    private string TimePlay;
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

    public string GetName()
    {
        return Name;
    }

    public string GetTimePlay()
    {
        return TimePlay;
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
        Life = LifeStart;
    }

    public void ResetDie()
    {
        //Coint = 0;
        Heart = HeartStart;
    }

    public void SetName(string value)
    {
        Name = value;
    }

    public void SetTimePlay(string value)
    {
        TimePlay = value;
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


}
