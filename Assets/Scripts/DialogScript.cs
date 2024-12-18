using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour {
    public GameObject DialogPrefabSmall;

    void Start() {
		// showing hint dialog a few seconds after the application starts
		Invoke("OpenHintDialog", 5f);
	}

    void OpenHintDialog() {
		Dialog.Open(DialogPrefabSmall, DialogButtonType.OK, "Hint", "Look at your hand to open a menu.", false);
	}
}
