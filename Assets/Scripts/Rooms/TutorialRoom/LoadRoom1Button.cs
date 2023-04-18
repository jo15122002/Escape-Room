using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadRoom1Button : MonoBehaviour
{
    public void activate()
    {
        RoomsManager.GetInstance().LoadRoom(1);
    }
}
