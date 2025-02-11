using System;
using UnityEngine;

public class NPCRickRubin : MonoBehaviour, IInteractable
{
    public Dialogue dialogue; // ✅ Reference to Dialogue Script

    public void Interact()
    {
        Debug.Log("✅ You interacted with: " + gameObject.name);

        if (dialogue != null)
        {
            Debug.Log("✅ Dialogue Found! Starting Rick Rubin Dialogue...");
            dialogue.gameObject.SetActive(true);
            gameObject.SetActive(true); // ✅ Make sure it starts disabled

        }
        else
        {
            Debug.LogError("❌ Dialogue script is MISSING on " + gameObject.name);
        }
    }
}
