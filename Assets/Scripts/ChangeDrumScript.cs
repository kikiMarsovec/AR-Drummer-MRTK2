using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrumScript : MonoBehaviour {

	public GameObject djembe;
	public GameObject drumSet;
	public GameObject bongos;
	public GameObject bringDrumInFrontObject;
	private BringDrumInFrontScript bringDrumInFrontScript;

	private int currentState = 0;
	// 0 - djembe
	// 1 - drumSet
	// 2 - bongos

	void Start() {
		// on start we disable all the drums except djembe
		djembe.SetActive(true);
		drumSet.SetActive(false);
		bongos.SetActive(false);
		bringDrumInFrontScript = bringDrumInFrontObject.GetComponent<BringDrumInFrontScript>();
		bringDrumInFrontScript.BringDrumInFront();
		Invoke("BringDrumInFrontAfterStart", 3f); // calling this method again 2 seconds after start, because I'd doesn't execute on HoloLens2
	}

	void BringDrumInFrontAfterStart() {
		bringDrumInFrontScript.BringDrumInFront();
	}

	public void ChangeDrum() {
		currentState = (currentState + 1) % 3;
		// change drum according to the current state
		switch (currentState) {
			case 0: // djembe
				bongos.SetActive(false);
				djembe.SetActive(true);
				break;
			case 1: // drum set
				djembe.SetActive(false);
				drumSet.SetActive(true);
				break;
			case 2: // bongos
				drumSet.SetActive(false);
				bongos.SetActive(true);
				break;
		}
		bringDrumInFrontScript.BringDrumInFront();
	}
}
