using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxColliderManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Room3Manager.Instance.countdown += 5f;
        }
    }
}
