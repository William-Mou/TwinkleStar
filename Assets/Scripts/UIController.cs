using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField usernameInputField; // 0
    public TMP_InputField genderInputField;   // 1
    public int InputSelected;
    public static string username;
    public static string gender;


    public void SwitchToCreateCharacterScene() => SceneManager.LoadScene(0, LoadSceneMode.Single);
    public void SwitchToStartScene() => SceneManager.LoadScene(1, LoadSceneMode.Single);
    public void SwitchToIntroScene() => SceneManager.LoadScene(2, LoadSceneMode.Single);
    public void SwitchToInfoScene() => SceneManager.LoadScene(3, LoadSceneMode.Single);
    public void SwitchToCreateStarScene() => SceneManager.LoadScene(4, LoadSceneMode.Single);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(usernameInputField.text);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter");
            username = usernameInputField.text;
            gender = genderInputField.text;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(gender))
            {
                Debug.Log("username:" + username + ", gender:" + gender);
            }
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab");
            InputSelected++;
            InputSelected %= 2;
            SelectInputField();
        }
        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0:
                    usernameInputField.Select();
                    break;
                case 1:
                    genderInputField.Select();
                    break;
            }
        }
        
    }

    public void UsernameSelected() => InputSelected = 0;
    public void GenderSelected() => InputSelected = 1;
}
