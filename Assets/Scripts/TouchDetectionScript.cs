using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.XR;

public class TouchDetectionScript : MonoBehaviour, IMixedRealityPointerHandler {

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
			Vector3 center = gameObject.transform.position;
			center.z -= gameObject.transform.lossyScale.z / 2;
			double radius = gameObject.transform.lossyScale.x / 2 * 1.1;

			if (Vector3.Distance(center, handPosition) <= radius) {
				// successfully played the drum
				Debug.Log("Drum successfully played.");
				Debug.Log(handPosition);
			} else {
				Debug.Log("Too far from center.");
			}
		}
	}

	/*
	 * TODO:
	 * - izracunaj ali je roka znotraj kroga (DONE)
	 * - cooldown za isto roko (Da ne triggeramo bobna dvakrat z isto roko. Za obe roki je manjsi cooldown ce npr zelimo izvesti Flam udarec po bobnu.)
	 * - posljemo info na neko kontrolno enoto, ki preveri cooldowne in prozi zvok od udarca (in kasneje prozi tudi animacije bobnov)
	 */

	// We don't need these methods, but they must be implemented
	void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData) {	}
	void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData) { }
	void IMixedRealityPointerHandler.OnPointerUp(MixedRealityPointerEventData eventData) { }
}
