using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                UICreateStar.latestPlanet = hit.collider.transform.parent.gameObject.name;
                // print(hit.collider.transform.parent.gameObject.name);
                print(UICreateStar.latestPlanet);
                UIController.SwitchToIntroScene();
            }
        }
            
    }
}
