using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // ✅ Dein NPC-Prefab (Stelle sicher, dass das `clothing.cs` enthält)
    public Transform[] spawnPoints; // ✅ Drei verschiedene Spawnpunkte

    void Start()
    {
        if (spawnPoints.Length < 3)
        {
            Debug.LogError("❌ Du brauchst mindestens 3 Spawnpunkte für NPCs!");
            return;
        }

        // ✅ Erstelle 3 NPCs mit unterschiedlichen Outfits
        for (int i = 0; i < 3; i++)
        {
            GameObject newNPC = Instantiate(npcPrefab, spawnPoints[i].position, Quaternion.identity);
            clothing npcClothing = newNPC.GetComponent<clothing>();

            if (npcClothing != null)
            {
                StartCoroutine(SetRandomOutfit(npcClothing));
            }
        }
    }

    IEnumerator SetRandomOutfit(clothing npc)
    {
        yield return new WaitForSeconds(0.1f); // Kurze Pause, damit alles geladen ist

        // ✅ Zufällige Hautfarbe
        int skinColor = UnityEngine.Random.Range(0, npc.skin_textures.Length);
        npc.skin_head.GetComponent<Renderer>().materials[0].mainTexture = npc.skin_textures[skinColor];
        npc.skin_body.GetComponent<Renderer>().materials[0].mainTexture = npc.skin_textures[skinColor];

        // ✅ Zufällige Haare
        int hairType = UnityEngine.Random.Range(0, 5);
        GameObject[] hairOptions = { npc.hair_a, npc.hair_b, npc.hair_c, npc.hair_d, npc.hair_e };
        hairOptions[hairType].SetActive(true);

        // ✅ Zufällige Kleidung
        GameObject[] outfits = { npc.banker_suit, npc.police_suit, npc.worker_suit };
        int outfitChoice = UnityEngine.Random.Range(0, outfits.Length);
        outfits[outfitChoice].SetActive(true);

        // ✅ Zufällige Schuhe
        GameObject[] shoes = { npc.shoes1, npc.shoes2, npc.shoes3 };
        int shoeChoice = UnityEngine.Random.Range(0, shoes.Length);
        shoes[shoeChoice].SetActive(true);
    }
}
