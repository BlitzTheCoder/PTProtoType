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
    public float headBob = 1;


    void Start()
    {

    }


    void Update()
    {

        LookAround();
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            Walk();
        }

    }

    void Walk()
    {
        float f = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        float s = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        transform.position += ((transform.forward * f) + (transform.right * s)) * walkSpeed;

    }

    void LookAround()
    {
        float lX = (invertXAxis) ? Input.GetAxisRaw("Mouse X") * -1: Input.GetAxisRaw("Mouse X") * 1;
        float lY = (invertYAxis) ? Input.GetAxisRaw("Mouse Y") * -1: Input.GetAxisRaw("Mouse Y") * 1;

        transform.Rotate(0, lX, 0);

        cam.transform.Rotate(lY, 0, 0);

        Mathf.Clamp(transform.rotation.y, -350, 0);

    }

}
