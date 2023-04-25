using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Room3Manager : MonoBehaviour
{
    private static Room3Manager instance;

    private bool gameStarted = false;
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> walls;
    private GameObject foxPlayer;
    [SerializeField] Material black;
    [SerializeField] Material rainbow;

    [SerializeField] private GameObject room;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private ObstacleSpawnerManager spawnerManager;

    public float countdown = 60f;

    public static Room3Manager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Si l'instance existe déjà et qu'elle n'est pas celle-ci, détruire cette instance.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Définir cette instance comme l'instance unique.
            instance = this;
        }
    }

    public void Update()
    {
        if(gameStarted) { 
            foxPlayer.transform.position = player.transform.position + new Vector3(0, -1f, 3);
            foxPlayer.transform.rotation = player.transform.rotation;
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.Round(countdown).ToString();

            if(countdown < 15)
            {
                StartCoroutine(setWallsRainbow());
            }
            else
            {
                StartCoroutine(setWallsInBlack());
            }
        }
    }

    public void scaleOverTime(GameObject objectToScale, Vector3 scale, float time)
    {
        StartCoroutine(ScaleOverTime(objectToScale, scale, time));
    }

    public IEnumerator ScaleOverTime(GameObject objectToScale, Vector3 scale, float time)
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        float currentTime = 0.0f;
        Vector3 startScale = objectToScale.transform.localScale;

        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            objectToScale.transform.localScale = Vector3.Lerp(startScale, scale, currentTime / time);
            yield return null;
        }
        objectToScale.transform.localScale = scale;
        yield return null;
        startRunner();
    }

    public IEnumerator ScaleOverCountdown(GameObject objectToScale, Vector3 scale)
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        float time = countdown;
        float currentTime = 0.0f;
        Vector3 startScale = objectToScale.transform.localScale;

        while (currentTime < time)
        {
            time = countdown;
            currentTime += Time.deltaTime;
            objectToScale.transform.localScale = Vector3.Lerp(startScale, new Vector3(1,1, scale.z * (4 / 60) * countdown), currentTime / time);
            yield return null;
        }
        objectToScale.transform.localScale = scale;
        yield return null;
    }

    private void startRunner()
    {
        foxPlayer = Instantiate(foxPrefab, player.transform.position + new Vector3(0, 0, 5), player.transform.rotation);
        foxPlayer.transform.localScale = new Vector3(0.5f,0.5f,0.5f);

        //find crosshair in childrens
        GameObject crosshair = GameObject.Find("Crosshair");
        crosshair.GetComponent<Renderer>().enabled = false;

        StartCoroutine(setWallsInBlack());

        spawnerManager.enabled = true;
        gameStarted = true;
        RoomsManager.GetInstance().StoreRoom(2);
        StartCoroutine(ScaleOverCountdown(room, Vector3.one));
    }

    private IEnumerator setWallsInBlack()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material = black;
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(countdown/4);
    }

    private IEnumerator setWallsRainbow()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material = rainbow;
        }
        yield return null;
    }
}
