using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialRoom1stButton : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] Light light;

    private float duration = 5.0f;
    private float distance = 0f;

    private float startIntensity = 24f;
    private float endIntensity = 0f;
    public void activate()
    {
        distance = wall.GetComponent<Renderer>().bounds.size.y * 1f;
        StartCoroutine(DescendWall());
    }

    private IEnumerator DescendWall()
    {
        float elapsedTime = 0.0f;
        Vector3 startPosition = wall.transform.position;
        Vector3 endPosition = startPosition - new Vector3(0.0f, distance, 0.0f);

        HelpText.GetHelpText().writeUIText("Wow le mur descend !");

        Camera cam = Camera.main;
        cam.GetComponent<PlayerCamera>().shake();

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float intensity = Mathf.Lerp(startIntensity, endIntensity, t);

            wall.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            elapsedTime += Time.deltaTime;
            light.intensity = intensity;
            yield return null;
        }

        wall.transform.position = endPosition;

        HelpText.GetHelpText().writeUIText("Je vois un autre bouton, allez y !");
        HelpText.GetHelpText().writeUIText("Vous pouvez vous déplacer avec les touches W A S D");
    }
}
