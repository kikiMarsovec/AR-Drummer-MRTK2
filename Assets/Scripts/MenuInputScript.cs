using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputScript : MonoBehaviour {

    public GameObject djembe;
    public GameObject drumTouchHandler;

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
        djembe.GetComponent<BoxCollider>().enabled = true;
        djembe.GetComponent<ObjectManipulator>().enabled = true;
		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = false;
	}

    public void DisableMovement() {
		djembe.GetComponent<BoxCollider>().enabled = false;
		djembe.GetComponent<ObjectManipulator>().enabled = false;
		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = true;
	}
}
