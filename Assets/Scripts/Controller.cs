using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public CursorLockMode wantedMode;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.up * 5;
        }
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * 3;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * 3;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * 3;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * 3;
        }

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        transform.GetChild(0).transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
