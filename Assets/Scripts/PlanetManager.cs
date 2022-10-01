using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject template;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        GameObject planet1 = Instantiate(template, new Vector3(100, 0, 0), Quaternion.identity, parent.transform);
        planet1.name = "Alzir";
        GameObject planet2 = Instantiate(template, new Vector3(-25, 0, 0), Quaternion.identity, parent.transform);
        planet2.name = "Antares";
    }

    // Update is called once per frame
    void Update()
    {
        parent.transform.eulerAngles += new Vector3(0, (float)0.8, 0);
    }
}
