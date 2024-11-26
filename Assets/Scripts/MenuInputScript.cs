using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputScript : MonoBehaviour {

    public GameObject drumTouchHandler;
	public GameObject djembe;
	public GameObject drumSet;
	public GameObject bongos; // TODO SET BONGOS IN EDITOR

	private void Start() {
		EnableMovement();
	}
	
	void Update() { // TODO only for testing - can be deleted later
		if (Input.GetKeyDown(KeyCode.Alpha1))
            EnableMovement();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            DisableMovement();
	}

    public void EnableMovement() {
		// djembe
        djembe.GetComponent<BoxCollider>().enabled = true;
        djembe.GetComponent<ObjectManipulator>().enabled = true;
		djembe.GetComponent<NearInteractionGrabbable>().enabled = true;
		// drumset
		drumSet.GetComponent<BoxCollider>().enabled = true;
		drumSet.GetComponent<ObjectManipulator>().enabled = true;
		drumSet.GetComponent<NearInteractionGrabbable>().enabled = true;
		// bongos TODO

		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = false;
	}

    public void DisableMovement() {
		// djembe
		djembe.GetComponent<BoxCollider>().enabled = false;
		djembe.GetComponent<ObjectManipulator>().enabled = false;
		djembe.GetComponent<NearInteractionGrabbable>().enabled = false;
		// drumset
		drumSet.GetComponent<BoxCollider>().enabled = false;
		drumSet.GetComponent<ObjectManipulator>().enabled = false;
		drumSet.GetComponent<NearInteractionGrabbable>().enabled = false;
		// bongos TODO

		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = true;
	}
}
