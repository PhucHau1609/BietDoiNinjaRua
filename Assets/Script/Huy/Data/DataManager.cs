using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    List<Data> listData = new List<Data>();

    //public void AddDataPlayer()
    //{
    //    listData.Add(new Data(
    //        GameManager.Instance.GetName(),
    //        ClockController.currentTime,
    //        ClockController.currentDate,
    //        GameManager.Instance.GetCoint()));
    //}

    //public void GetDataPlayer()
    //{
    //    foreach (var infor in listData)
    //    {
    //        Debug.Log("Name: " + infor.Name +
    //            "| Time: " + infor.TimeFinished +
    //            "| Date: " + infor.DateFinished +
    //            "| Coint: " + infor.CountCoint);
    //    }
    //}
}
