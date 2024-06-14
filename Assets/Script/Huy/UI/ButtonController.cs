using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
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
