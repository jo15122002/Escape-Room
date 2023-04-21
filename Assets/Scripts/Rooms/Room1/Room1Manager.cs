using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Manager : MonoBehaviour
{
    [SerializeField] private List<GoldenRollSpawner> goldenRollSpawners;
    [SerializeField] private GameObject loadRoom2Button;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.inventory.Count == 10 && !win)
        {
            HelpText.GetHelpText().writeUIText("Bravo ! Vous tiendrez au moins une semaine de confinement avec ça !");
            loadRoom2Button.SetActive(true);
            foreach(GoldenRollSpawner spawner in goldenRollSpawners)
            {
                spawner.InvokeRepeating("Spawn", 0.1f, 0.1f);
            }
            win = true;
        }
    }
}
