using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script is applied to a player object
/// and a Camera must be set.
/// </summary>

[RequireComponent(typeof(Camera))]
public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    public GameObject playerBody;
    /// <summary>
    /// Invert values for camera X axis
    /// </summary>
    public bool invertXAxis = false;
    /// <summary>
    /// Invert values for camera Y axis
    /// </summary>
    public bool invertYAxis = true;
    /// <summary>
    /// Walk Speed in Meters per Second
    /// </summary>
    public float walkSpeed = 1;
    /// <summary>
    /// Multiplyer for how fast to move Camera
    /// </summary>
    public float cameraSensitivity = 1;
    /// <summary>
    /// Altitude for camera z movement while walking (not implemented)
    /// </summary>
    public float headBob = 1; 


    void Start()
    {

    }


    void Update()
    {

        LookAround();

        Walk();



    }


    /// <summary>
    /// Using any controls that invoke the "Vertical" and "Horizontal" inputs
    /// the player can walk forwards or backwards and left or right.
    /// </summary>
    void Walk()
    {
        //Set values to somewhere between -1 and 1 depending on inputs
        float f = Input.GetAxis("Vertical") * Time.deltaTime; 
        float s = Input.GetAxis("Horizontal") * Time.deltaTime;

        //Move the player either positively or negatively along their respective axis depending on input at the specified walking speed.
        transform.position += ((transform.forward * f) + (transform.right * s)) * walkSpeed;

    }


    /// <summary>
    /// Using any controls, in this case the mouse or a DualShock 4 controller,
    /// the player can freely look around, with the Cameras pitch locked to look
    /// between either straight up or straight down.
    /// </summary>
    void LookAround()
    {
        //Set values to somewhere between -1 and 1 depending on inputs and inverts that number depending on invertAxis booleans
        float lX = Input.GetAxis("Camera X") * (invertXAxis ? -1 : 1) * cameraSensitivity;
        float lY = Input.GetAxis("Camera Y") * (invertYAxis ? -1 : 1) * cameraSensitivity;

        float newAngle = cam.transform.localEulerAngles.x + lY; //Grab current camera Euler Angle to use in following if statement.
        if (newAngle > 80 && newAngle < 280) return; //Locks camera range to straight up and straight down

        transform.Rotate(0, lX, 0);

        cam.transform.Rotate(lY, 0, 0);



    }

}
