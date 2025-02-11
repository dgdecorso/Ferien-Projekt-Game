using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public Image mapUI; // ✅ Das UI-Image für die Karte
    private bool isMapActive = false; // ✅ Startet deaktiviert

    void Start()
    {
        if (mapUI != null)
        {
            mapUI.gameObject.SetActive(false); // ✅ Karte ist am Anfang ausgeblendet
        }
        else
        {
            Debug.LogError("❌ MiniMap UI Image ist nicht zugewiesen!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // ✅ Drücke M, um die Karte ein-/auszuschalten
        {
            isMapActive = !isMapActive;
            mapUI.gameObject.SetActive(isMapActive); // ✅ Aktiviert/deaktiviert das gesamte UI-Image
        }
    }
}
