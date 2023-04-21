using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierGate : MonoBehaviour
{
    [SerializeField] private GameObject cashierGate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PlayerManager.Instance.inventory.Count == 10)
        {
            StartCoroutine(OpenGate());
        }
    }

    IEnumerator OpenGate()
    {
        Quaternion fromRotation = cashierGate.transform.rotation;
        Quaternion toRotation = Quaternion.AngleAxis(-90f, Vector3.up) * fromRotation;
        float elapsedTime = 0;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            cashierGate.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cashierGate.transform.rotation = toRotation;
        gameObject.SetActive(false);
    }
}
