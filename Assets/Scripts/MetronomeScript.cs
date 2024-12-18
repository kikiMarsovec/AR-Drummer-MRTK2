using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MetronomeScript : MonoBehaviour
{
    public GameObject AudioManagerObject;
    private AudioManager audioManager;

    private bool isEnabled = false;
    private bool settingBpm = false;

    public float bpm = 80f; // min = 40, max = 120

    private float secondsPerBeat; // Time interval between beats
    private float nextBeatTime; // Tracks when the next beat should occur
    private float timer; // Keeps track of the elapsed time

	// text mesh pro
	public GameObject textBpm;
	private TextMeshPro textMeshPro;

	// slider
	public GameObject sliderObject;
	private PinchSlider slider;

    // near menu
    public GameObject nearMenu;

	void Start() {
        audioManager = AudioManagerObject.GetComponent<AudioManager>();
		textMeshPro = textBpm.GetComponent<TextMeshPro>();
		// textMeshPro.text = "Hello World";
		slider = sliderObject.GetComponent<PinchSlider>();
		// Debug.Log("Current slider value: " + slider.SliderValue);
	}

    void StartPlayingMetronome() {
        secondsPerBeat = 60f / bpm;
        timer = 0f;
        nextBeatTime = secondsPerBeat;
        isEnabled = true;
    }

    void StopPlayingMetronome() {
        isEnabled = false;
    }

    void SetMetronomeBpm(float currentBpm) {
        bpm = currentBpm;
		secondsPerBeat = 60f / bpm;
	}

    void Update() {
        if (settingBpm) {
            float sliderValue = slider.SliderValue; // get value from slider
            float currentBpm = Mathf.Round(Mathf.Lerp(40f, 120f, sliderValue)); // interpolate value so it's between 40 and 120
			textMeshPro.text = currentBpm.ToString(); // set NearMenu text to current bpm
            SetMetronomeBpm(currentBpm); // set bpm to current bpm
        }

        if (!isEnabled)
            return;

        timer += Time.deltaTime;
        if (timer >= nextBeatTime) {
            PlayMetronomeSound();
            nextBeatTime += secondsPerBeat;
        }
    }

    void PlayMetronomeSound() {
		audioManager.PlayDrumSound("metronome");
	}

    public void EnableMetronome() {
		ShowNearMenu();
        StartPlayingMetronome();
		}

    public void DisableMetronome() {
        StopPlayingMetronome();
        HideNearMenu(); // just in case NearMenu is still open
    }

    private void ShowNearMenu() {
        nearMenu.SetActive(true);
        Camera mainCamera = Camera.main;
		Vector3 cameraForward = mainCamera.transform.forward;
		nearMenu.transform.position = mainCamera.transform.position + cameraForward * 0.5f;
        settingBpm = true;
	}

    public void HideNearMenu() {
        nearMenu.SetActive(false);
        settingBpm = false;
    }
}
