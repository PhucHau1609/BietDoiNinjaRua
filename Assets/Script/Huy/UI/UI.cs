using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;

    private void Update()
    {
        UpdateGoldUI();
    }
    public void UpdateGoldUI()
    {
        goldText.text = GameManager.Instance.GetCoint().ToString();

        if (GameManager.Instance.GetHeart() >= 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (GameManager.Instance.GetHeart() == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (GameManager.Instance.GetHeart() == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (GameManager.Instance.GetHeart() < 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }

        Debug.Log("Coint: " + GameManager.Instance.GetCoint());
        Debug.Log("Heart: " + GameManager.Instance.GetHeart());
    }
}
