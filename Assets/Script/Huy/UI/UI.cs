using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : Singleton<UI>
{
    [SerializeField] private TMP_Text goldText;

    void Start()
    {
        PlayerPrefs.SetInt("goldGlobalVar", 0);
        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        goldText.text = PlayerPrefs.GetInt("goldGlobalVar", 0).ToString();
        Debug.Log(PlayerPrefs.GetInt("goldGlobalVar"));
    }
}
