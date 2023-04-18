using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*//put the camera at the player's position
        transform.position = player.position;

        //Rotate the camera on x with the player rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        */
        //rotate the camera with the mouse
        float mouseY = Input.GetAxis("Mouse Y");
        float nextPos = transform.rotation.eulerAngles.x - mouseY;
        if((nextPos <= 89) || (nextPos >= 270))
        {
            transform.Rotate(-mouseY, 0, 0);
        }
    }

    public void shake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
