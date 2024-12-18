using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputScript : MonoBehaviour {

    public GameObject drumTouchHandler;
	public GameObject djembe;
	public GameObject drumSet;
	public GameObject bongos;
	public GameObject metronomeHandlerObject;
	private MetronomeScript metronomeScript;

	// buttons
	public GameObject enableMovementButton;
	public GameObject playDrumsButton;
	public GameObject enableMetronomeButton;
	public GameObject disableMetronomeButton;

	private void Start() {
		EnableMovement();
		metronomeScript = metronomeHandlerObject.GetComponent<MetronomeScript>();
	}

    public void EnableMovement() {
		// disable enableMovementButton and enable playDrumsButton on the hand menu
		enableMovementButton.SetActive(false);
		playDrumsButton.SetActive(true);
		// djembe
		djembe.GetComponent<BoxCollider>().enabled = true;
        djembe.GetComponent<ObjectManipulator>().enabled = true;
		djembe.GetComponent<NearInteractionGrabbable>().enabled = true;
		// drumset
		drumSet.GetComponent<BoxCollider>().enabled = true;
		drumSet.GetComponent<ObjectManipulator>().enabled = true;
		drumSet.GetComponent<NearInteractionGrabbable>().enabled = true;
		// bongos 
		bongos.GetComponent<BoxCollider>().enabled = true;
		bongos.GetComponent<ObjectManipulator>().enabled = true;
		bongos.GetComponent<NearInteractionGrabbable>().enabled = true;

		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = false;
	}

    public void DisableMovement() {
		// enable enableMovementButton and disable playDrumsButton on the hand menu
		enableMovementButton.SetActive(true);
		playDrumsButton.SetActive(false);
		// djembe
		djembe.GetComponent<BoxCollider>().enabled = false;
		djembe.GetComponent<ObjectManipulator>().enabled = false;
		djembe.GetComponent<NearInteractionGrabbable>().enabled = false;
		// drumset
		drumSet.GetComponent<BoxCollider>().enabled = false;
		drumSet.GetComponent<ObjectManipulator>().enabled = false;
		drumSet.GetComponent<NearInteractionGrabbable>().enabled = false;
		// bongos
		bongos.GetComponent<BoxCollider>().enabled = false;
		bongos.GetComponent<ObjectManipulator>().enabled = false;
		bongos.GetComponent<NearInteractionGrabbable>().enabled = false;

		drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().isEnabled = true;
	}

	public void EnableMetronome() {
		// handling buttons
		enableMetronomeButton.SetActive(false);
		disableMetronomeButton.SetActive(true);
		// enable metronome
		metronomeScript.EnableMetronome();
	}

	public void DisableMetronome() {
		// handling buttons
		enableMetronomeButton.SetActive(true);
		disableMetronomeButton.SetActive(false);
		// disable metronome
		metronomeScript.DisableMetronome();
	}
}
