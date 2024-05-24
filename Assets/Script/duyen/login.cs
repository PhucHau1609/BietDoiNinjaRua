using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class login : MonoBehaviour
{
    
    [SerializeField] Animator animatorPlayerLogin;
    [SerializeField] float timeWayPlay;
    public TMP_InputField edtName, edtPass;
    public TMP_Text txtMess;
    private EventSystem eveSy;
    public TMP_InputField first; // Đảm bảo rằng trường này được gán trong Inspector
    public Button Login; // Đảm bảo rằng trường này được gán trong Inspector

    // Start được gọi trước khi khung hình đầu tiên được cập nhật
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

    // Update được gọi một lần mỗi khung hình
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            // Kiểm tra nếu Login button đã được gán
            if (Login != null)
            {
                Login.onClick.Invoke();
            }
            else
            {
                Debug.LogError("Login Button không được gán trong Inspector.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eveSy
                .currentSelectedGameObject
                .GetComponent<Selectable>()
                .FindSelectableOnDown();
            if (next != null) next.Select();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Selectable next = eveSy
                .currentSelectedGameObject
                .GetComponent<Selectable>()
                .FindSelectableOnUp();
            if (next != null) next.Select();
        }
    }

    public void checkLogin()
    {
        var name = edtName.text;
        var pass = edtPass.text;

        if (name.Equals("beduyencute") && pass.Equals("141105") ||
            name.Equals("huy") && pass.Equals("120797") ||
            name.Equals("hau") && pass.Equals("160905") ||
            name.Equals("phuc") && pass.Equals("130505"))
        {
            txtMess.text = "Bắt đầu nào....";
            StartCoroutine(WayPlay());
        }
        else
        {
            txtMess.text = "Tên người dùng hoặc mật khẩu không đúng";
        }
    }

    private IEnumerator WayPlay()
    {
        animatorPlayerLogin.SetTrigger("Play");
        yield return new WaitForSeconds(timeWayPlay);
        SceneManager.LoadScene("Map 1");

    }

}
