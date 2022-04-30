using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetandMoon : MonoBehaviour
{
    public GameObject planet;
    public GameObject moon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetSpin();
    }

    private void PlanetSpin()
    {
        planet.transform.Rotate(0 , 0, 50 * Time.deltaTime);
    }
}
