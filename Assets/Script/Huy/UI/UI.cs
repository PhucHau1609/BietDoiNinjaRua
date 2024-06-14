using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text timePlay;
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text buletText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    [SerializeField] Slider sliderHeart;

    private void Update()
    {
        UpdateGoldUI();
    }
    public void UpdateGoldUI()
    {
        timePlay.text = ClockController.currentTime.ToString();
        lifeText.text = GameManager.Instance.GetLife().ToString();
        goldText.text = GameManager.Instance.GetCoint().ToString();
        buletText.text = GameManager.Instance.GetCountBulet().ToString();
        sliderHeart.value = GameManager.Instance.GetHeart();


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
    }

}
