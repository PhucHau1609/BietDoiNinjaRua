using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("goldGlobalVar", PlayerPrefs.GetInt("goldGlobalVar") + 1);
            Destroy(gameObject);
        }
    }

   
}
