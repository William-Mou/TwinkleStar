using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                print(hit.collider.transform.parent.gameObject.name);
            }
        }
            
    }
}
