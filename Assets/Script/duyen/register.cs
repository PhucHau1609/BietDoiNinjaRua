using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class register : MonoBehaviour
{
    public TMP_InputField edtEmail, edtName, edtPass, edtrePass;
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
        
    }
    private void checkRegister()
    {
        var email = edtEmail;
        var name = edtName;
        var pass =  edtPass;
        var repass = edtrePass;
        
        if(pass != repass)
        {

        } else {
            
        }
    }
}
