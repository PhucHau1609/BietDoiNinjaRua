using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSC : MonoBehaviour
{
    [SerializeField] GameObject Boss;

    void Update()
    {
        if (Boss == null)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
