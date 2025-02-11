using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{
    public static Collection instance;

    public TMP_Text itemsText; // ✅ UI-Anzeige für den Counter
    public int Items = 0; // ✅ Anzahl gesammelter Items
    public GameObject explosionPrefab; // ✅ Explosionseffekt
    public Transform explosionTarget; // ✅ Objekt, das explodiert
    public Camera mainCamera; // ✅ Aktuelle Kamera
    public Camera cameraEnd; // ✅ Endszene-Kamera

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateText();

        // ✅ Stelle sicher, dass die Hauptkamera beim Start aktiv ist
        if (mainCamera != null && cameraEnd != null)
        {
            mainCamera.enabled = true;
            cameraEnd.enabled = false; // ✅ Endkamera ausblenden, bis Explosion passiert
        }
    }

    public void IncreaseItems(int v)
    {
        Items += v; // ✅ Richtiges Hochzählen der Items
        UpdateText(); // ✅ Aktualisiert den UI-Text
        Debug.Log($"✅ Items gesammelt: {Items}");
    }

    private void UpdateText()
    {
        if (itemsText != null)
        {
            itemsText.text = "ITEMS: " + Items.ToString(); // ✅ Zeigt die Anzahl an
        }
        else
        {
            Debug.LogError("❌ itemsText ist NULL! Stelle sicher, dass der UI-Text im Inspector zugewiesen ist.");
        }
    }

    void Update()
    {
        if (Items >= 4 && Input.GetKeyDown(KeyCode.F)) // ✅ Explosion & Kamerawechsel bei 4+ Items
        {
            ExplodeObject();
            SwitchToCameraEnd();
        }
    }

    void ExplodeObject()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("evil"); // ✅ Alle Objekte mit "evil" finden

        if (enemies.Length > 0)
        {
            Debug.Log($"💥 BOOM! Zerstöre {enemies.Length} böse Objekte!");

            foreach (GameObject enemy in enemies)
            {
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, enemy.transform.position, Quaternion.identity); // ✅ Explosionseffekt an jeder Position
                }

                Destroy(enemy, 2f); // ✅ Entfernt das Objekt
            }
        }
        else
        {
            Debug.LogWarning("❌ Keine bösen Objekte mit dem Tag 'evil' gefunden!");
        }
    }

    void SwitchToCameraEnd()
    {
        if (cameraEnd != null)
        {
            Debug.Log("🎥 Wechsel zur Endkamera!");

            mainCamera.enabled = false; // ✅ Deaktiviert Hauptkamera
            cameraEnd.enabled = true; // ✅ Aktiviert "CameraEnd"
        }
        else
        {
            Debug.LogError("❌ 'CameraEnd' ist nicht zugewiesen!");
        }
    }
}
