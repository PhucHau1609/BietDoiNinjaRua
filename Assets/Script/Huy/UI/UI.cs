using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    void Start()
    {
        PlayerPrefs.SetInt("goldGlobalVar", 0);

        // Gọi hàm cập nhật UI khi game bắt đầu
        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        goldText.text = PlayerPrefs.GetInt("goldGlobalVar", 0).ToString();
    }
}
