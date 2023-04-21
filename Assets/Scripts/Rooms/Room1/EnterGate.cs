using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGate : MonoBehaviour
{
    [SerializeField] GameObject leftGate;
    [SerializeField] GameObject rightGate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(OpenGate(leftGate, -90));
            StartCoroutine(OpenGate(rightGate, 90));
            HelpText.GetHelpText().writeUIText("Une pandémie mondiale s'est déclarée !");
            HelpText.GetHelpText().writeUIText("Trouvez l'objet le plus précieux actuellement !");
            HelpText.GetHelpText().writeUIText("10 rouleaux de papier toilette !");
        }
    }

    IEnumerator OpenGate(GameObject obj, float rotationAngle)
    {
        float duration = 1f;
        Quaternion fromRotation = obj.transform.rotation;
        Quaternion toRotation = Quaternion.AngleAxis(rotationAngle, Vector3.up) * fromRotation;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = toRotation;
        gameObject.SetActive(false);
    }
}
