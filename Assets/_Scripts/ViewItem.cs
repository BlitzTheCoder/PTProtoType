using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewItem : MonoBehaviour {

    GameObject viewingObject;

    Transform objTransform;

    public Transform viedwPos;

    public ViewItem(GameObject hitObject)
    {
        viewingObject = hitObject;
    }

	void Start () {
        objTransform = viewingObject.transform;
	}
	

	void Update () {
		
	}
}
