using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class TestTouchScript : MonoBehaviour, IMixedRealityPointerHandler
{
	private new Renderer renderer; // TODO DELETE

	void IMixedRealityPointerHandler.OnPointerDown(MixedRealityPointerEventData eventData) {
		Debug.Log("We get to here");
		if (eventData.Pointer is PokePointer) {
			// TODO TO SE NE ZAZENE V EDITORJU (MAYBE JE TREBA SPROBAT DEJANSKO NA HOLOLENS-IH)
			Debug.Log("But not to here");
			// ce dela, bo kocka spremenila barvo na neko random barvo
			renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); // TODO DELETE
		}
	}


	// We don't need these methods, but they must be implemented
	void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData) {	}
	void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData) { }
	void IMixedRealityPointerHandler.OnPointerUp(MixedRealityPointerEventData eventData) { }

	// Start is called before the first frame update
	void Start()
    {
		renderer = GetComponent<Renderer>(); // TODO DELETE
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
