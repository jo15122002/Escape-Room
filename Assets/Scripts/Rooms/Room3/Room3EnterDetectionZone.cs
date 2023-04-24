using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3EnterDetectionZone : MonoBehaviour
{
    [SerializeField] GameObject room3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Room3Manager.Instance.scaleOverTime(room3, new Vector3(1, 1, 8), 2.0f);
        }
    }
}
