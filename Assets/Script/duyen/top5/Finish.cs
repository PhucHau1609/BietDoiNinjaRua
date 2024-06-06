using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Finish : MonoBehaviour
{
     private EventSystem eveSy;
    public TMP_InputField first; // Đảm bảo rằng trường này được gán trong Inspector
    public Button buttonTop; // Đảm bảo rằng trường này được gán trong Inspector

    // Start is called before the first frame update
    void Start()
    {
        eveSy = EventSystem.current;

        // Kiểm tra nếu first đã được gán
        if (first != null)
        {
            first.Select();
        }
        else
        {
            Debug.LogError("First Selectable không được gán trong Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.Return))
        {
            if (buttonTop != null)
            {
                buttonTop.onClick.Invoke();
            }
            else
            {
                Debug.LogError("Top Button không được gán trong Inspector.");
            }
        }  

    }
}
