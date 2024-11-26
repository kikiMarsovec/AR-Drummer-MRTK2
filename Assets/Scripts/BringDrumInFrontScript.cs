using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringDrumInFrontScript : MonoBehaviour
{
	public GameObject djembe;
	public GameObject drumSet;
	public GameObject bongos; // TODO SET BONGOS IN EDITOR

	private void Start() {
		BringDrumInFront();
	}

	public void BringDrumInFront() {
		Transform cameraTransform = Camera.main.transform;
		Vector3 positionInFrontOfCamera = cameraTransform.position + cameraTransform.forward * 2f;
		djembe.transform.position = positionInFrontOfCamera;
		drumSet.transform.position = positionInFrontOfCamera;
		// TODO ISTO NAREDI SE BONGOS
	}
}
