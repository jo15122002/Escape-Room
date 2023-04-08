using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    [SerializeField] Light[] linkedLights;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Light light in linkedLights)
        {
            light.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLights()
    {
        on = !on;
        if (on)
        {
            foreach (Light light in linkedLights)
            {
                light.enabled = true;
            }
        }
        else
        {
            foreach (Light light in linkedLights)
            {
                light.enabled = false;
            }
        }
    }
}
