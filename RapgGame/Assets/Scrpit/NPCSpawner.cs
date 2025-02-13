using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // ✅ NPC-Prefab (enthält `clothing.cs` und `Test_script.cs`)
    public Transform[] spawnPoints; // ✅ Wo NPCs erscheinen
    public int npcCount = 5; // ✅ Anzahl der zu spawnenden NPCs

    void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    IEnumerator SpawnNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newNPC = Instantiate(npcPrefab, spawnPoint.position, Quaternion.identity);

            // ✅ Kleidung generieren
            clothing npcClothing = newNPC.GetComponent<clothing>();
            if (npcClothing != null)
            {
                StartCoroutine(SetRandomOutfit(npcClothing));
            }

            // ✅ NPC sofort laufen lassen
            Test_script npcAI = newNPC.GetComponent<Test_script>();
            if (npcAI != null)
            {
                npcAI.ready = true; // ✅ NPC kann sofort loslaufen
            }

            yield return new WaitForSeconds(1f); // ✅ Verzögerung zwischen Spawns
        }
    }

    IEnumerator SetRandomOutfit(clothing npc)
    {
        yield return new WaitForSeconds(0.1f); // Warte kurz, damit alles geladen ist

        // ✅ Zufällige Hautfarbe
        int skinColor = Random.Range(0, npc.skin_textures.Length);
        npc.skin_head.GetComponent<Renderer>().materials[0].mainTexture = npc.skin_textures[skinColor];
        npc.skin_body.GetComponent<Renderer>().materials[0].mainTexture = npc.skin_textures[skinColor];

        // ✅ Zufällige Haare
        GameObject[] hairOptions = { npc.hair_a, npc.hair_b, npc.hair_c, npc.hair_d, npc.hair_e };
        hairOptions[Random.Range(0, hairOptions.Length)].SetActive(true);

        // ✅ Zufällige Kleidung
        GameObject[] outfits = { npc.banker_suit, npc.police_suit, npc.worker_suit };
        outfits[Random.Range(0, outfits.Length)].SetActive(true);

        // ✅ Zufällige Schuhe
        GameObject[] shoes = { npc.shoes1, npc.shoes2, npc.shoes3 };
        shoes[Random.Range(0, shoes.Length)].SetActive(true);
    }
}
