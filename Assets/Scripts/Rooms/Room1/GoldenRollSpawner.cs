using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenRollSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldenRollPrefab;
    // Start is called before the first frame update
    public float spawnInterval = 0.5f;
    private Vector3 spawnPosition;

    private List<GameObject> spawnList = new List<GameObject>();

    void Start()
    {
        
    }

    void Spawn()
    {
        spawnPosition = transform.position;
        if (spawnList.Count > 40)
        {
            Destroy(spawnList[0]);
            spawnList.RemoveAt(0);
        }
        GameObject goldenRoll = Instantiate(goldenRollPrefab, spawnPosition, Quaternion.identity);
        //add random force to object
        goldenRoll.GetComponent<Rigidbody>().AddForce(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        spawnList.Add(goldenRoll);
    }
}
