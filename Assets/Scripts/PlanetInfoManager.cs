using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoManager : MonoBehaviour
{
    public GameObject template;
    public Text textTemplate;
    public Canvas canvas;
    public Slider slider;

    private List<Planet> planets;
    private readonly Vector3[] posArray5 =
        {
            new Vector3(-200,-75,0),
            new Vector3(-100,25,0),
            new Vector3(100,-125,0),
            new Vector3(200,-25,0),
            new Vector3(300,75,0),
        };

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        IEnumerable<string> files = Directory
            .EnumerateFiles("Assets\\Data", "*.json", SearchOption.TopDirectoryOnly);

        planets = new();
        foreach (string file in files)
        {
            string jsonString = File.ReadAllText(file);
            planets.Add(JsonUtility.FromJson<Planet>(jsonString));
        }

        int max = 0, min = (int)1e9;
        foreach (Planet planetData in planets)
        {
            if ((int)Mathf.Log(planetData.distance, 2) > max) max = (int)Mathf.Log(planetData.distance, 2);
            if ((int)Mathf.Log(planetData.distance, 2) < min) min = (int)Mathf.Log(planetData.distance, 2);
        }

        slider.maxValue = max;
        slider.minValue = min;

        slider.onValueChanged.AddListener((float val) => SliderCallback(val));

        SliderCallback(min);
    }

    int prev = -1;
    private List<GameObject> hasDrawGameObject = new();
    private List<Text> hasDrawUI = new();
    private void SliderCallback(float val)
    {
        List<Planet> filterPlanets = planets.FindAll(c => (int)Mathf.Log(c.distance, 2) == (int)val);
        if(val != prev)
        {
            foreach(GameObject obj in hasDrawGameObject)
            {
                Destroy(obj);
            }
            foreach (Text text in hasDrawUI)
            {
                Destroy(text.gameObject);
            }
            hasDrawGameObject = new();
            hasDrawUI = new();
            foreach (Planet planetData in filterPlanets.GetRange(0, Mathf.Min(5, filterPlanets.Count)))
            {
                GameObject planet = Instantiate(template, posArray5[filterPlanets.IndexOf(planetData)], Quaternion.identity);
                planet.name = planetData.name;

                Text text = Instantiate(textTemplate, planet.transform.position + new Vector3(0, 50, 0), Quaternion.identity, canvas.transform);
                text.text = planet.name;

                hasDrawGameObject.Add(planet);
                hasDrawUI.Add(text);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
