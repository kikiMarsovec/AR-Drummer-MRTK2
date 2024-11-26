using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrumScript : MonoBehaviour {

	public GameObject djembe;
	public GameObject drumSet;
	public GameObject bongos; // TODO SET BONGOS IN EDITOR
	public GameObject bringDrumInFrontObject;
	private BringDrumInFrontScript bringDrumInFrontScript;

	private int currentState = 0;
	// 0 - djembe
	// 1 - drumSet
	// 2 - bongos

	void Start() {
		bringDrumInFrontScript = bringDrumInFrontObject.GetComponent<BringDrumInFrontScript>();
        // on start we disable all the drums except djembe
		djembe.SetActive(true);
		drumSet.SetActive(false);
		// bongos.SetActive(false); TODO uncomment when bongos are implemented
	}

	public void ChangeDrum() {
		currentState = (currentState + 1) % 3;
		// change drum according to the current state
		switch (currentState) {
			case 0: // djembe
				// TODO uncomment when bongos are implemented
				// bongos.SetActive(false);
				djembe.SetActive(true);
				break;
			case 1: // drum set
				djembe.SetActive(false);
				drumSet.SetActive(true);
				break;
			case 2: // bongos
				drumSet.SetActive(false);
				// TODO uncomment when bongos are implemented
				// bongos.SetActive(true);
				break;
		}
		bringDrumInFrontScript.BringDrumInFront();
	}

	void Update() { // TODO DELETE
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			ChangeDrum();
		}
	}
}
