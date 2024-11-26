using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringDrumInFrontScript : MonoBehaviour
{
	public GameObject djembe;

	public void BringDrumInFront() {
		Transform cameraTransform = Camera.main.transform;
		Vector3 positionInFrontOfCamera = cameraTransform.position + cameraTransform.forward * 0.5f;
		djembe.transform.position = positionInFrontOfCamera;
	}

    // Update is called once per frame
    void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			BringDrumInFront();
		}
	}
}
