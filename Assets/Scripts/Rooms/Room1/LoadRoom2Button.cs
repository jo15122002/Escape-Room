using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom2Button : MonoBehaviour
{
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void activate()
    {
        RoomsManager.GetInstance().LoadRoom(2);
    }
}
