using UnityEngine;

public class coins : MonoBehaviour
{
    private int coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coint"))  // Fixed typo
        {
            coin++;
            Debug.Log("Coins collected: " + coin);

            Destroy(other.gameObject);

            if (Collection.instance != null)
            {
                Collection.instance.IncreaseItems(1); // Pass the missing argument
            }
            else
            {
                Debug.LogError("Collection.instance is null. Make sure the Collection script is in the scene.");
            }
        }
    }
}
