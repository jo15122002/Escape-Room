using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerManager : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float spawnTime = 2f;

    [SerializeField] List<ObstacleSpawner> obstacleSpawners;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            int randomIndex = Random.Range(0, obstacleSpawners.Count);
            for(int i = 0; i < obstacleSpawners.Count; i++)
            {
                if(i != randomIndex)
                {
                    obstacleSpawners[i].SpawnObstacle();
                }
            }
            elapsedTime = 0f;
        }
    }
}
