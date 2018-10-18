using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    GameObject hitObject;

    void Update ()
    {
        CastRay();

        if (Input.GetMouseButtonDown(0))
        {
            ViewItem v = new ViewItem(hitObject);
        }
    }

    /// <summary>
    /// Casts out a ray from the Player Camera position and returns a hit if the object has the "Interactable" tag.
    /// </summary>
    void CastRay()
    {
        
        RaycastHit hit;

        
        
        // The distance at which the other object is when hit.
        float theDistance;

        // Sets the forward of the Ray at a specified distance.
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;

        // Sets the Ray as red in the editor during play.
        Debug.DrawRay(transform.position, forward, Color.red);

        //If the Raycast hits an object...
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            //If that object has the "Interactable" Tag...
            if (hit.collider.gameObject.tag == "Interactable")
            {
                theDistance = hit.distance;

                print(theDistance + " " + hit.collider.gameObject.name);

                hitObject = hit.collider.gameObject;
            }
        }
    }
}
