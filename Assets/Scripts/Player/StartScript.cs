using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
