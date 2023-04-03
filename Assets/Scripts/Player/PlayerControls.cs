using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 0f;
    [SerializeField] float sidewaysForce = 10f;
    [SerializeField] float jumpForce = 10f;

    private bool enabled = true;

    private bool zPressed;
    private bool sPressed;
    private bool qPressed;
    private bool dPressed;
    private bool spacePressed;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(new Vector3(0,400,1000));
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
        {
            zPressed = Input.GetKey(KeyCode.Z);
            sPressed = Input.GetKey(KeyCode.S);
            qPressed = Input.GetKey(KeyCode.Q);
            dPressed = Input.GetKey(KeyCode.D);
            spacePressed = Input.GetKeyDown(KeyCode.Space);
        }
        else
        {
            zPressed = false;
            sPressed = false;
            qPressed = false; 
            dPressed = false;
            spacePressed = false;
        }


    }

    private void FixedUpdate()
    {
        //ZQSD player controls
        if (zPressed)
        {
            rb.AddForce(new Vector3(0, 0, forwardForce * Time.deltaTime), ForceMode.VelocityChange);
        }
        if (sPressed)
        {
            rb.AddForce(new Vector3(0, 0, -forwardForce * Time.deltaTime), ForceMode.VelocityChange);
        }
        if (qPressed)
        {
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
        if (dPressed)
        {
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }

        //Jump
        if (spacePressed)
        {
            Debug.Log("Jump");
            rb.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
        }
    }
}
