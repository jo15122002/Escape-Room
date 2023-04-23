using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (hit.collider.tag)
                {
                    case ("OtherButton"):
                        Type componentType = Type.GetType(hit.collider.name);
                        UnityEngine.Component component = hit.collider.GetComponent(componentType);
                        MethodInfo activateMethod = componentType.GetMethod("activate");
                        activateMethod.Invoke(component, null);
                        break;
                    case ("CollectibleObject"):
                        PlayerManager.Instance.inventory.Add(hit.collider.name);
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case ("UselessBooks"):
                        HelpText.GetHelpText().writeUIText(Room2Manager.Instance.getRandomUselessBookText());
                        break;
                    case ("UsefulBook"):
                        HelpText.GetHelpText().writeUIText(Room2Manager.Instance.getUsefulBookHint(hit.collider.name));
                        break;
                    case ("KeyBook"):
                        Room2Manager.Instance.cycleKeyBook(hit.collider.gameObject);
                        break;
                }
            }
        }
        
    }
}
