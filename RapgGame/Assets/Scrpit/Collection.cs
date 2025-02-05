using UnityEngine;
using TMPro;

public class Collection : MonoBehaviour
{
    public static Collection instance;

    public TMP_Text itemsText;
    public int Items = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    void Start()
    {
        UpdateText();
    }

    public void IncreaseItems(int v)
    {
        Items += v;
        UpdateText();
    }

    private void UpdateText()
    {
        if (itemsText != null)
        {
            itemsText.text = "ITEMS: " + Items.ToString();
        }
        else
        {
            Debug.LogError("itemsText is not assigned in the inspector!");
        }
    }
}
