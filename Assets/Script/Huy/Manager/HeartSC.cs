using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSC : MonoBehaviour
{
    [Header("Set")]
    [SerializeField] int addHeart = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddHeart(addHeart);
            Destroy(gameObject);
            
        }
    }
}
