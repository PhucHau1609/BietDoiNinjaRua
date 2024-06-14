using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSC : MonoBehaviour
{
    [SerializeField] int setArrow = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetCountBuletCong(setArrow);
            Destroy(gameObject);
        }
    }
}
