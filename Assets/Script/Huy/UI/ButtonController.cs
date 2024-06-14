using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private void Start()
    {
        //SaveData.Instance.GetDataPlayer();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map 1");
        ClockController.Instance.StartTime();
    }

    public void Exit()
    {
        Application.Quit();
        //Debug.Log("Quit Game...");
        SceneManager.LoadScene("Home");
    }

}
