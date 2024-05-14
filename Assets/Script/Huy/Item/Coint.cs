using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int currentGold = PlayerPrefs.GetInt("goldGlobalVar", 0);
            currentGold++;
            PlayerPrefs.SetInt("goldGlobalVar", currentGold);
            Destroy(gameObject);

            // Gọi hàm cập nhật UI tại đây
            FindObjectOfType<UI>().UpdateGoldUI();
        }
    }
}
