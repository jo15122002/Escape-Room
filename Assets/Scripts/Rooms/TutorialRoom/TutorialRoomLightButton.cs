using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoomLightButton : MonoBehaviour
{
    [SerializeField] Light linkedLight;
    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        linkedLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        ToggleLights();
    }

    public void ToggleLights()
    {
        on = !on;
        linkedLight.enabled = on;
    }
}
