using UnityEngine;

public class coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coint"))  // ✅ Stellt sicher, dass das Item richtig erkannt wird!
        {
            Debug.Log("✅ Coin eingesammelt: " + other.gameObject.name);

            Destroy(other.gameObject); // ✅ Entfernt das eingesammelte Item

            if (Collection.instance != null)
            {
                Collection.instance.IncreaseItems(1); // ✅ Erhöht den Counter in Collection.cs
            }
            else
            {
                Debug.LogError("❌ Collection.instance ist NULL! Stelle sicher, dass 'Collection' in der Szene ist.");
            }
        }
        else
        {
           
        }
    }
}
