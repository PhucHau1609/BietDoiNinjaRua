using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private int gold;

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    void Start()
    {
        Gold = PlayerPrefs.GetInt("goldGlobalVar");
        
    }

    void Update()
    {
        goldText.text = gold.ToString();
    }
}
