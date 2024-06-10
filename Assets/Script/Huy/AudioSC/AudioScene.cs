using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioScene : MonoBehaviour
{
    private AudioManager audioManager;
    public int[] sceneNumber;
    public string[] nameScene; 


    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < sceneNumber.Length; i++)
        {
            audioManager = FindObjectOfType<AudioManager>();

            if (currentSceneIndex == sceneNumber[i])
            {
                audioManager.Play(nameScene[i]);
            }
            else if (currentSceneIndex == sceneNumber[i])
            {
                audioManager.Play(nameScene[i]);
            }
            else if (currentSceneIndex == sceneNumber[i])
            {
                audioManager.Play(nameScene[i]);
            }
        }
        
        
    }

    void OnDestroy()
    {
        if (audioManager != null)
        {
            audioManager.StopAll();
        }
    }

     
}
