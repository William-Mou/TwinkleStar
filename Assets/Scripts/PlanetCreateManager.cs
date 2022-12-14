using System.Collections.Generic;
using SFB;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCreateManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject template;
    public Scrollbar scrollbar;
    public Button pauseButton;
    public Button screenshotButton;
    public TMP_Dropdown createType;
    public Slider createVMag;
    public Slider createPeriod;
    public Slider createBP_RP;
    public Slider createRatio;
    public Planet newPlanet;

    private int iter;
    private bool pause;
    public int ratioA = 1;
    public int ratioB = 2;
    const int ratioBias = 25;
    GameObject planet1;
    GameObject planet2;
    Vector3 centerPosition;
    Planet planet;
    int preventRatioA = 1;
    int preventRatioB = 2;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        string name = UICreateStar.latestPlanet;
        List<Planet> planets = PlanetInfoManager.planets;
        planet = planets?.Find(x => x.name == name) ?? new Planet("ASASSN-V J100211.71-192537.4"); // for test
        pause = false;
        iter = 1;
        Application.targetFrameRate = 60;
        centerPosition = parent.transform.position;
        planet1 = Instantiate(template, new Vector3(planet.ratioA * ratioBias, 0, 0) + centerPosition, Quaternion.identity, parent.transform);
        material = planet1.transform.GetChild(1).gameObject.GetComponent<Renderer>().material;
        material.color = GenColor(planet);
        planet.originColor = material.color;
        planet2 = Instantiate(template, new Vector3(-1 * planet.ratioB * ratioBias, 0, 0) + centerPosition, Quaternion.identity, parent.transform);
        material = planet2.transform.GetChild(1).gameObject.GetComponent<Renderer>().material;
        material.color = GenColor(planet);
        planet.originColor = material.color;

        scrollbar.onValueChanged.AddListener((float val) => ScrollbarCallback(val));
        pauseButton.onClick.AddListener(() => PauseButtonCallback());
        screenshotButton.onClick.AddListener(() => ScreenshotButtonCallback());
    }

    private Color GenColor(Planet planet)
    {
        float T = (float)((1 / (planet.BPRP * 0.92 + 1.7) + 1 / (planet.BPRP * 0.92 + 0.62)) * 4600);
        Color color = Mathf.CorrelatedColorTemperatureToRGB(T);
        print(color);
        return color;
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
            ratioA = UICreateStar.new_planet?.ratioA ?? ratioA;
            ratioB = UICreateStar.new_planet?.ratioB ?? ratioB;
            if (UICreateStar.new_planet.type != "Binary Star")
            {
                planet2.SetActive(false);
            }
            else if (UICreateStar.new_planet.type == "Binary Star")
            {
                planet2.SetActive(true);
            }
            material = planet1.transform.GetChild(1).gameObject.GetComponent<Renderer>().material;
            material.color = GenColor(UICreateStar.new_planet);
            material = planet2.transform.GetChild(1).gameObject.GetComponent<Renderer>().material;
            material.color = GenColor(UICreateStar.new_planet);

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
        print("call");
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
