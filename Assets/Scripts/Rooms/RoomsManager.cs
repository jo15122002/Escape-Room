using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class RoomsManager : MonoBehaviour
{
    private static RoomsManager _instance;

    public static RoomsManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<RoomsManager>();
            if (_instance == null)
            {
                GameObject go = new GameObject("RoomsManager");
                _instance = go.AddComponent<RoomsManager>();
            }
        }

        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        /*StoreRoom(1);
        StoreRoom(2);
        StoreRoom(3);*/
    }

    public void LoadRoom(int roomId)
    {
        GameObject room = GameObject.Find("Room" + roomId);
        room.SetActive(true);

        if(roomId%2 == 1)
        {
            room.transform.rotation = new Quaternion(0, 0, 0, 0);
            room.transform.position = new Vector3(-2.525329f, 2.732308f, -5.323605f);
        }
        else if(roomId != -1 && roomId != 0)
        {
            room.transform.rotation = new Quaternion(0, 180, 0, 0);
            room.transform.position = new Vector3(2.5f, 2.74f, -9.62f);
        }

        StoreRoom(roomId-2);


        Transform wall = room.transform.Find("MovingWall");
        _instance.StartCoroutine(DescendWall(wall));

        GameObject oldRoom = GameObject.Find("Room" + (roomId - 1));
        if(oldRoom != null)
        {
            Transform oldWall = oldRoom.transform.Find("MovingWall");
            _instance.StartCoroutine(DescendWall(oldWall));
        }
    }

    public void StoreRoom(int roomId)
    {
        GameObject room = GameObject.Find("Room" + roomId);
        if(room == null)
        {
            return;
        }
        room.transform.position = new Vector3(23.2f, 7*roomId+2*roomId+1, -12.7f);
        //room.SetActive(false);
    }

    private IEnumerator DescendWall(Transform wall)
    {
        float elapsedTime = 0.0f;
        float duration = 5f;
        Vector3 startPosition = wall.transform.position;
        float distance = wall.transform.localScale.y;
        Vector3 endPosition = startPosition - new Vector3(0.0f, distance, 0.0f);

        Camera cam = Camera.main;
        cam.GetComponent<PlayerCamera>().shake(5f, 0.1f);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            wall.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wall.transform.position = endPosition;
        yield return null;
    }

    public void riseWall(int roomId)
    {
        GameObject room = GameObject.Find("Room" + roomId);
        Transform wall = room.transform.Find("MovingWall");
        _instance.StartCoroutine(RiseWall(roomId));
    }
    private IEnumerator RiseWall(int roomId)
    {
        GameObject room = GameObject.Find("Room" + roomId);
        Transform wall = room.transform.Find("MovingWall");
        if(wall != null && roomId != -1)
        {
            float elapsedTime = 0.0f;
            float duration = 2.5f;
            Vector3 startPosition = wall.transform.position;
            float distance = wall.transform.localScale.y;
            Vector3 endPosition = startPosition + new Vector3(0.0f, distance, 0.0f);

            Camera cam = Camera.main;
            cam.GetComponent<PlayerCamera>().shake(2.5f, 0.05f);

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;

                wall.transform.position = Vector3.Lerp(startPosition, endPosition, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            wall.transform.position = endPosition;
            yield return null;
        }
    }
}
