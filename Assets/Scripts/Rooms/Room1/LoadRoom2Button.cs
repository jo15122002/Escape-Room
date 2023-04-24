using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom2Button : MonoBehaviour
{
    [SerializeField] Light room2Light;
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void activate()
    {
        room2Light.enabled = true;
        RoomsManager.GetInstance().LoadRoom(2);
    }
}
