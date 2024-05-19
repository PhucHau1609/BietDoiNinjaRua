using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class login : MonoBehaviour
{
    public TMP_InputField edtName, edtPass;
    public TMP_Text txtMess;
    private EventSystem eveSy;
    private Selectable first;
    private Button Login;
    // Start is called before the first frame update
    void Start()
    {
        eveSy = EventSystem.current;
        first.Select();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Return))
        {
            Login.onClick.Invoke();
        }

        if (Input.GetKeyDown (KeyCode.Tab))
        {
            Selectable next = eveSy
                .currentSelectedGameObject
                .GetComponent<Selectable>()
                .FindSelectableOnDown();
            if (next != null) next.Select();
        }

        if (Input.GetKey (KeyCode.LeftShift))
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

        if (name.Equals ("beduyencute") && pass.Equals("141105") || name.Equals ("huy") && pass.Equals ("120797") || name.Equals ("hau") && pass.Equals ("160905") || name.Equals ("phuc") && pass.Equals ("130505"))
        {
            SceneManager.LoadScene("Map 1");
        } else {
            txtMess.text = "Username or password not right";
        }
    }
}
