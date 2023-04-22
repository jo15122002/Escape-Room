using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{

    private static Room2Manager _instance;

    public static Room2Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Room2Manager>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(Room2Manager).Name);
                    _instance = singleton.AddComponent<Room2Manager>();
                }
            }

            return _instance;
        }
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getRandomUselessBookText()
    {
        List<string> uselessBookSentences = new List<string>
        {
            "Ces livres ont l'air très intéréssants mais ce n'est pas ce qu'on cherche.",
            "Un livre de cuisine ...",
            "Harry Potter ? Ca va jamais marcher avec un nom comme ça ...",
            "Les livres... les jeunes de nos jours ne connaissent plus..."
        };
        return uselessBookSentences[Random.Range(0, uselessBookSentences.Count)];
    }
}
