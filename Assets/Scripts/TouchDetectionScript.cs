using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.XR;
using Microsoft.MixedReality.Toolkit;
using Unity.XR.CoreUtils;

public class TouchDetectionScript : MonoBehaviour, IMixedRealityPointerHandler {

	public string drumType = "";
	public string drumName = "";
	public GameObject drumTouchHandler;
	private Transform centerObj;

	private void Start() {
		centerObj = transform.GetChild(0);
	}

	void IMixedRealityPointerHandler.OnPointerDown(MixedRealityPointerEventData eventData) {
		if (eventData.Pointer is PokePointer) {
			// check which hand triggered the pointer
			GameObject hand = null;
			string handType = null;
			switch (eventData.Handedness.ToString()) {
				case "Right":
					handType = "right";
					hand = GameObject.Find("Right_PokePointer(Clone)"); // this might be slow, maybe check children inside MixedRealityPlayspace to speed up
					break;
				case "Left":
					handType = "left";
					hand = GameObject.Find("Left_PokePointer(Clone)"); // this might be slow, maybe check children inside MixedRealityPlayspace to speed up
					break;
			}
			Vector3 handPosition = hand.transform.position;
			Vector3 center = centerObj.position;
			double radius = gameObject.transform.lossyScale.x / 2 * 1.1;
			double distance = Vector3.Distance(center, handPosition);

			if (distance > radius) {
				// Touched too far from the center
				Debug.Log("Too far from center.");
				return;
			} else {
				// Touched drum successfully
				drumTouchHandler.GetComponent<TouchDetectionHandlerScript>().HandleTouch(drumType, drumName, handType, distance/radius);
			}
		}
	}

	// We don't need these methods, but they must be implemented
	void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData) {	}
	void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData) { }
	void IMixedRealityPointerHandler.OnPointerUp(MixedRealityPointerEventData eventData) { }
}
