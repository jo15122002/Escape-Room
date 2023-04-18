using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDetectionZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RoomsManager.GetInstance().riseWall(int.Parse(transform.parent.name.Substring(4)));
            GameObject.Destroy(this.gameObject);
        }
    }
}
