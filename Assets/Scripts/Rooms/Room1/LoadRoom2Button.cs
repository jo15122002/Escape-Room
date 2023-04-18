using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom2Button : MonoBehaviour
{
    public void activate()
    {
        RoomsManager.GetInstance().LoadRoom(2);
    }
}
