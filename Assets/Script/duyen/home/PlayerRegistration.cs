using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerRegistration : MonoBehaviour
{
    [SerializeField] Animator animatorPlayerLogin;
    [SerializeField] float timeWayPlay;
    public TMP_InputField edtName, edtPass, edtrePass;
    public TMP_Text txtMess;
    private EventSystem eveSy;
    public TMP_InputField first; // Đảm bảo rằng trường này được gán trong Inspector
    public Button buttonLogin; // Đảm bảo rằng trường này được gán trong Inspector
    public Button buttonRegister; //
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
            // Kiểm tra nếu Login button đã được gán
            if (buttonRegister != null)
            {
                buttonRegister.onClick.Invoke();
            }
            else
            {
                Debug.LogError("Register Button không được gán trong Inspector.");
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
   
    public void checkRegister()
    {
        var pass =  edtPass.text;
        var repass = edtrePass.text;
        
        if(pass == repass)
        {
            txtMess.text = "Let's start....";
            buttonRegister.interactable = false;
            buttonRegister.interactable = false;
            StartCoroutine(WayPlay());
        }
        else
        {
            txtMess.text = "mk sai";
        }
    }
    public class ds{
        public string name1;
        public string pass1;
        public ds(string name, string pass){
            name1 = name;
            pass1 = pass;
        }
    }
    private IEnumerator WayPlay()
    {
        animatorPlayerLogin.SetTrigger("Play");
        yield return new WaitForSeconds(timeWayPlay);
        SceneManager.LoadScene("Map 1");

    }
}
