using System.Collections.Generic;
using SFB;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlanetIntroManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject template;
    public Scrollbar scrollbar;
    public Button pauseButton;
    public Button screenshotButton;

    private int iter;
    private bool pause;
    public int ratioA = 1;
    public int ratioB = 2;
    const int ratioBias = 25;
    GameObject planet1;
    GameObject planet2;
    Vector3 centerPosition;
    int preventRatioA = 1;
    int preventRatioB = 2;
    // Start is called before the first frame update
    void Start()
    {
        string name = UICreateStar.latestPlanet;
        List<Planet> planets = PlanetInfoManager.planets;
        Planet planet = planets?.Find(x => x.name == name) ?? new Planet("ASASSN-V J100211.71-192537.4");
        pause = false;
        iter = 1;
        Application.targetFrameRate = 60;
        centerPosition = parent.transform.position;

        planet1 = Instantiate(template, new Vector3(0, 0, 0) + centerPosition, Quaternion.identity, parent.transform);
        /*
        planet1 = Instantiate(template, new Vector3(ratioA * ratioBias, 0, 0) + centerPosition, Quaternion.identity, parent.transform);
        planet1.name = "Alzir";
        planet2 = Instantiate(template, new Vector3(-1 * ratioB * ratioBias, 0, 0) + centerPosition, Quaternion.identity, parent.transform);
        planet2.name = "Antares";
        */

        scrollbar.onValueChanged.AddListener((float val) => ScrollbarCallback(val));
        pauseButton.onClick.AddListener(() => PauseButtonCallback());
        screenshotButton.onClick.AddListener(() => ScreenshotButtonCallback());
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            parent.transform.eulerAngles = new Vector3(0, 1 * iter, 0);
            scrollbar.value = (float)iter / 720;
            iter %= 720;
            iter++;
            ratioA = UICreateStar.new_planet.ratioA;
            ratioB = UICreateStar.new_planet.ratioB;
        }
        if (ratioA != preventRatioA || ratioB != preventRatioB)
        {
            preventRatioA = ratioA;
            preventRatioB = ratioB;
            planet1.transform.position = new Vector3(ratioA * ratioBias, 0, 0) + centerPosition;
            planet2.transform.position = new Vector3(-1 * ratioB * ratioBias, 0, 0) + centerPosition;
        }

    }

    void ScrollbarCallback(float value)
    {
        if (pause)
        {
            iter = (int)(value * 720);
            parent.transform.eulerAngles = new Vector3(0, 1 * iter, 0);
        }
    }
    void PauseButtonCallback()
    {
        pause = !pause;
    }

    void ScreenshotButtonCallback()
    {
        string fileName = StandaloneFileBrowser.SaveFilePanel("Save File", "", "screenshot", "png");

        if (fileName.Length != 0)
        {
            UnityEngine.ScreenCapture.CaptureScreenshot(fileName);
        }
    }
}
