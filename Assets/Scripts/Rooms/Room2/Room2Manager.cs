using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{

    private static Room2Manager _instance;
    [SerializeField] Light playerLight;
    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> keyBooks;
    private Hashtable bookCyclePositions = new Hashtable();
    private Hashtable correctBookCyclePositions = new Hashtable();

    [SerializeField] GameObject loadRoom3Button;

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
        playerLight.transform.position = player.transform.position;
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
        return uselessBookSentences[UnityEngine.Random.Range(0, uselessBookSentences.Count)];
    }

    public string getUsefulBookHint(string objectName)
    {
        List<string> hints = new List<string>
        {
            "Chapitre 1 : Il faisait beau, le ciel est BLEU.",
            "Chapitre 2 : Le temps est chaud, les coquilecots ROUGES fleurissent par milliers.",
            "Chapitre 3 : Avec la formule magique, il a OUVERT la porte.",
            "Chapitre 4 : "
        };

        return hints[int.Parse(objectName.Substring(objectName.Length - 1))];
    }

    public void cycleKeyBook(GameObject book)
    {
        GameObject parent = book.transform.parent.gameObject;
        int index = int.Parse(book.name.Substring(book.name.Length - 1));
        if (!bookCyclePositions.Contains(book.name))
        {
            bookCyclePositions.Add(book.name, 0);
        }
        bookCyclePositions[book.name] = ((int)bookCyclePositions[book.name] + 1) % keyBooks.Count;

        GameObject nextBook = keyBooks[(int)bookCyclePositions[book.name]];
        GameObject bookObject = Instantiate(nextBook, parent.transform.position, parent.transform.rotation, parent.transform);
        bookObject.name = book.name;
        bookObject.tag = book.tag;
        bookObject.transform.parent = parent.transform;

        Destroy(book);

        this.checkBookOrder();
    }

    private void checkBookOrder()
    {
        bool correctBookOrder = false;
        if(correctBookCyclePositions.Count == 0)
        {
            this.initializeCorrectBookOrder();
        }
        Debug.Log("Checking book order");
        Debug.Log("Correct book order : " + correctBookCyclePositions);
        Debug.Log("Current book order : " + bookCyclePositions);

        foreach (var book in correctBookCyclePositions)
        {
            
        }

        if ()
        {
            Debug.Log("Correct book order");
            loadRoom3Button.SetActive(true);
        }
        else
        {
            loadRoom3Button.SetActive(false);
        }
    }

    private void initializeCorrectBookOrder()
    {
        correctBookCyclePositions.Add("keyBook0", 0);
        correctBookCyclePositions.Add("keyBook1", 1);
        correctBookCyclePositions.Add("keyBook2", 2);
        correctBookCyclePositions.Add("keyBook3", 3);
    }
}
