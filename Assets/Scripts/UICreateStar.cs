using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICreateStar : MonoBehaviour
{
    // Start is called before the first frame update
    public static string latestPlanet;
    public TMP_InputField StarNameInputField; // 0
    public TMP_Dropdown StarTypeDropdown;   // 1
    public Slider MeanVMag;  // 2
    public Slider Period;    // 3
    public Slider BP_RP;     // 4
    public int InputSelected;


    public Planet new_planet;

    void Start()
    {
        new_planet = new Planet();

    }

    // Update is called once per frame
    void Update()
    {
        print("Latest !!!" + latestPlanet);
        char separator = Path.DirectorySeparatorChar;
        // Debug.Log(usernameInputField.text);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            new_planet.name = StarNameInputField.text;
            new_planet.type = StarTypeDropdown.captionText.text;
            new_planet.meanVMag = MeanVMag.value;
            new_planet.Period = Period.value;
            new_planet.BPRP = BP_RP.value;
            latestPlanet = new_planet.name;
            if (!string.IsNullOrEmpty(new_planet.name) && !string.IsNullOrEmpty(new_planet.type))
            {
                string planetJson = JsonUtility.ToJson(new_planet);
                System.IO.File.WriteAllText(Application.persistentDataPath + $"{separator}star{separator}" + new_planet.name + ".json", planetJson);
                print(Application.persistentDataPath + "star" + new_planet.name + ".json");
                SwitchToIntroScene();
            }

        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab");
            InputSelected++;
            InputSelected %= 5;
            SelectInputField();
        }
        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0:
                    StarNameInputField.Select();
                    break;
                case 1:
                    StarTypeDropdown.Select();
                    break;
                case 2:
                    MeanVMag.Select();
                    break;
                case 3:
                    Period.Select();
                    break;
                case 4:
                    BP_RP.Select();
                    break;
            }
        }

    }

    public void StarNameSelected() => InputSelected = 0;
    public void StarTypeSelected() => InputSelected = 1;
    public void MeanVMagSelected() => InputSelected = 2;
    public void PeriodSelected() => InputSelected = 3;
    public void BP_RPSelected() => InputSelected = 4;

    public void SwitchToCreateCharacterScene() => SceneManager.LoadScene(0, LoadSceneMode.Single);
    public void SwitchToStartScene() => SceneManager.LoadScene(1, LoadSceneMode.Single);
    public void SwitchToIntroScene() => SceneManager.LoadScene(2, LoadSceneMode.Single);
    public void SwitchToInfoScene() => SceneManager.LoadScene(3, LoadSceneMode.Single);
    public void SwitchToCreateStarScene() => SceneManager.LoadScene(4, LoadSceneMode.Single);
}
