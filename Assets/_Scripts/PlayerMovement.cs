using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public GameObject playerBody;
    public bool invertXAxis = false;
    public bool invertYAxis = true;

    public float walkSpeed = 1;
    public float cameraSensitivity = 1;
    public float headBob = 1;


    void Start()
    {

    }


    void Update()
    {

        LookAround();

        Walk();



    }

    void Walk()
    {
        float f = Input.GetAxis("Vertical") * Time.deltaTime;
        float s = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.position += ((transform.forward * f) + (transform.right * s)) * walkSpeed;

    }

    void LookAround()
    {
        float lX = Input.GetAxis("Camera X") * (invertXAxis ? -1 : 1) * cameraSensitivity;
        float lY = Input.GetAxis("Camera Y") * (invertYAxis ? -1 : 1) * cameraSensitivity;

        float newAngle = cam.transform.localEulerAngles.x + lY;
        if (newAngle > 80 && newAngle < 280) return;

        transform.Rotate(0, lX, 0);

        cam.transform.Rotate(lY, 0, 0);



    }

}
