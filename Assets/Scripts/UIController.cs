using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void SwitchToCreateCharacterScene() => SceneManager.LoadScene(0, LoadSceneMode.Single);
    public void SwitchToStartScene() => SceneManager.LoadScene(1, LoadSceneMode.Single);
    public void SwitchToInfoScene() => SceneManager.LoadScene(2, LoadSceneMode.Single);
    public void SwitchToIntroScene() => SceneManager.LoadScene(3, LoadSceneMode.Single);
    public void SwitchToCreateStarScene() => SceneManager.LoadScene(4, LoadSceneMode.Single);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("IntroScene"))
            {
                SwitchToInfoScene();
            }
            SwitchToStartScene();
        }
    }
}
