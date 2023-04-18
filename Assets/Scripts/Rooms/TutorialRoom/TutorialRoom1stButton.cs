using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class TutorialRoom1stButton : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] Light light;

    public void activate()
    {
        HelpText.GetHelpText().writeUIText("Wow le mur descend !");
        RoomsManager.GetInstance().LoadRoom(0);
        GameObject.Destroy(wall);
        GameObject.Destroy(this.GameObject());
        StartCoroutine(DimLight());
    }

    private IEnumerator DimLight()
    {
        float elapsedTime = 0.0f;
        float duration = 5f;

        float startIntensity = 24f;
        float endIntensity = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float intensity = Mathf.Lerp(startIntensity, endIntensity, t);

            elapsedTime += Time.deltaTime;
            light.intensity = intensity;
            yield return null;
        }

        HelpText.GetHelpText().writeUIText("Je vois un autre bouton, allez y !");
        HelpText.GetHelpText().writeUIText("Vous pouvez vous déplacer avec les touches W A S D");
    }
}
