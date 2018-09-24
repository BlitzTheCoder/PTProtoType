using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public GameObject playerBody;

    public float walkSpeed = 1;
    public float headBob = 1;


    void Start()
    {

    }


    void Update()
    {
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


}
