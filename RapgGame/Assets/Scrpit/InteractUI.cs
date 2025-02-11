using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject; // UI panel
    [SerializeField] private PlayerConvo playerConvo;

    private void Update()
    {
        if (playerConvo == null)
        {
            Debug.LogError("playerConvo is NULL! Assign it in the Inspector.");
            return;
        }

        if (playerConvo.CanInteract()) // Only show UI when player is near NPC
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        if (containerGameObject != null) containerGameObject.SetActive(true);
    }

    private void Hide()
    {
        if (containerGameObject != null) containerGameObject.SetActive(false);
    }
}
