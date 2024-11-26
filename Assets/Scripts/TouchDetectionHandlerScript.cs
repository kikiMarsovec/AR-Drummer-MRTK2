using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetectionHandlerScript : MonoBehaviour {

	public bool isEnabled = true;
	public float differentHandCooldown = 0.06f;
	public float sameHandCooldown = 0.15f;
	Dictionary<string, float> cooldownDictionary = new Dictionary<string, float>();

	public GameObject AudioManagerObject;
	private AudioManager audioManager;

	private void Start() {
		audioManager = AudioManagerObject.GetComponent<AudioManager>();	
	}

	public void HandleTouch(string drumType, string drumName, string handType, double distance) {
		if (!isEnabled)
			return; // isn't enabled

		if (!CooldownCheck(drumType, drumName, handType))
			return; // cooldown failed

		PlaySound(drumType, drumName, distance);
	}

	private void PlaySound(string drumType, string drumName, double distance) {
		switch (drumType+drumName) {
			case "djembe":
				if (distance < 0.36) {
					audioManager.PlayDrumSound("djembe-bass");
				} else {
					audioManager.PlayDrumSound("djembe-snare");
				}
				break;
			case "drumsetbass":
				audioManager.PlayDrumSound("drumset-bass");
				break;
			case "drumsetsnare":
				audioManager.PlayDrumSound("drumset-snare");
				break;
			case "drumsettom1":
				audioManager.PlayDrumSound("drumset-tom1");
				break;
			case "drumsettom2":
				audioManager.PlayDrumSound("drumset-tom2");
				break;
			case "drumsetfloortom":
				audioManager.PlayDrumSound("drumset-floortom");
				break;
			case "drumsethihat":
				audioManager.PlayDrumSound("drumset-hihat");
				break;
			case "drumsetcrash":
				audioManager.PlayDrumSound("drumset-crash");
				audioManager.PlayDrumSound("drumset-bass"); // play Crash and Bass simultaneously when Crash is hit
				break;
			case "drumsetride":
				audioManager.PlayDrumSound("drumset-ride");
				break;
			// TODO check AudioManager.cs for other sound names
			
			default:
				Debug.Log("No such drum: " + drumType + "-" + drumName);
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