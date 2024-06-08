using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator fxAddHeart;
    [SerializeField] ParticleSystem getCointPTC;
    [SerializeField] ParticleSystem getArrowPTC;


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Next level
        if (collision.gameObject.tag == "NextLevel")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            if (currentSceneIndex == totalScenes - 1)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }

        if (collision.gameObject.tag == "Coint")
        {
            getCointPTC.Play();
        }

        if (collision.gameObject.tag == "Heart")
        {
            //addHeartPTC.Play();
            fxAddHeart.SetTrigger("Get");
        }

        if (collision.gameObject.tag == "Arrow")
        {
            getArrowPTC.Play();
        }
    }


}
