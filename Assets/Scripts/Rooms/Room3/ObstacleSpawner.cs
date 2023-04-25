using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;

    public void SpawnObstacle()
    {
        if(enabled)
        {
            GameObject instance = Instantiate(obstacle, transform.position, transform.rotation);

            instance.AddComponent<ObstacleBehavior>();
        }
    }
}
