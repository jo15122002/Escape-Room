using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rayDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //shoot a raycast where the player is looking
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit, rayDistance))
        {
            switch (hit.collider.tag)
            {
                case ("LightSwitch"):
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.GetComponent<LightButton>().ToggleLights();
                    }
                    break;
            }
        }
        
    }
}
