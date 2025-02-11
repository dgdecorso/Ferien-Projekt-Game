using System;
using UnityEngine;

public class ExampleObject : MonoBehaviour, IInteractable
{
    public Dialogue dialogue; // ✅ Reference to the Dialogue script

    public void Interact()
    {
        Debug.Log("✅ You interacted with: " + gameObject.name);

        // ✅ If it's KDOT_DAMN, only show this chat bubble
        if (gameObject.name == "KDOT_DAMN")
        {
            ChatBubble3D.Create(transform, new Vector3(0, 2f, 0f), ChatBubble3D.IconType.Happy, "NEW KUNG FU KENNY!");
            return; // ✅ Stops execution here, so no other interactions trigger!
        }

        // ✅ Check if this is Rick Rubin
        if (gameObject.name == "RickRubin" && CompareTag("NPC"))
        {
            if (dialogue != null)
            {
                Debug.Log("✅ Dialogue UI Activated! Starting Dialogue...");
                dialogue.gameObject.SetActive(true); 
                dialogue.StartDialogue();
            }
            else
            {
                Debug.LogError("❌ Dialogue script is missing on " + gameObject.name);
            }
            return; // ✅ Stops further execution
        }

        // ✅ Normal chat bubble for all other NPCs
        if (GetComponent<ChatBubble3D>() != null)
        {
            ChatBubble3D.Create(transform, new Vector3(0, 2f, 0f), ChatBubble3D.IconType.Happy, "Hey there!");
        }
        else
        {
            Debug.LogError("❌ ChatBubble3D is missing on " + gameObject.name);
        }
    }
}
