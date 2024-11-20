using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetectionHandlerScript : MonoBehaviour {

	public bool isEnabled = true;
	public float differentHandCooldown = 0.01f;
	public float sameHandCooldown = 0.1f;
	Dictionary<string, float> cooldownDictionary = new Dictionary<string, float>();

	public void HandleTouch(string drumType, string drumName, string handType, double distance) {
		if (!isEnabled)
			return; // isn't enabled

		if (!CooldownCheck(drumType, drumName, handType)) {
			return; // cooldown failed
		}

		PlaySound(drumType, drumName, distance);
	}
	/*
	 * TODO:
	 * - determine if okay because of cooldown (by each hand)
	 * - deretmine sound (based on drum type, drum name and distance)
	 * - play sound
	 */

	private void PlaySound(string drumType, string drumName, double distance) {
		switch (drumType+drumName) {
			case "djembe":
				if (distance < 0.4) {
					Debug.Log("Play Djembe bass");
				} else {
					Debug.Log("Play Djembe snare");
				}
				break;

			default:
				Debug.Log("No such drum");
				break;
		}
	}

	private bool CooldownCheck(string drumType, string drumName, string handType) {
		float currentTime = Time.time;
		float previousTime;
		if (handType == "right") {
			// check for same hand cooldown
			if (cooldownDictionary.TryGetValue(drumType + drumName + "right", out previousTime)) {
				if (currentTime - previousTime < sameHandCooldown)
					return false;
			} else {
				cooldownDictionary.Add(drumType + drumName + "right", currentTime);
			}
			// check for different hand cooldown
			if (cooldownDictionary.TryGetValue(drumType + drumName + "left", out previousTime)) {
				if (currentTime - previousTime < differentHandCooldown)
					return false;
			}
		} else if (handType == "left") {
			// check for same hand cooldown
			if (cooldownDictionary.TryGetValue(drumType + drumName + "left", out previousTime)) {
				if (currentTime - previousTime < sameHandCooldown)
					return false;
			} else {
				cooldownDictionary.Add(drumType + drumName + "left", currentTime);
			}
			// check for different hand cooldown
			if (cooldownDictionary.TryGetValue(drumType + drumName + "right", out previousTime)) {
				if (currentTime - previousTime < differentHandCooldown)
					return false;
			}
		}
		cooldownDictionary[drumType+drumName+handType] = currentTime;
		return true;
	}
}