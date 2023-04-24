using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set the player at the start of the game
        transform.position = new Vector3(-0.8f, 1.49f, -4.93f);
        transform.rotation = new Quaternion(0,180,0,0);

        HelpText helpText = HelpText.GetHelpText();
        helpText.writeUIText("Bienvenue dans mon jeu!");
        helpText.writeUIText("Demarrons sans plus tarder !");
        helpText.writeUIText("Pour commencer, vous pouvez intéragir avec les objets avec la touche E");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
