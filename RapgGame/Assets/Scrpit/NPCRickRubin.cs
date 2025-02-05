using UnityEngine;
using UnityEngine.UI; // ✅ Required for UI Text
using System.Collections;
using System.Collections.Generic;

public class Coins : MonoBehaviour {
    public Text displayText; // UI Text element

    public void Interact()
    {
        if (displayText != null) {
            displayText.text = "Whatever you want to display";
        } else {
            Debug.LogError("displayText is not assigned in the Inspector!");
        }
    }

    void Start() { }
    void Update() { }
}
