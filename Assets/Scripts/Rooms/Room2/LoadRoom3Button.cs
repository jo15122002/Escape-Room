using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom3Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RoomsManager.GetInstance().LoadRoom(3);
    }
}
