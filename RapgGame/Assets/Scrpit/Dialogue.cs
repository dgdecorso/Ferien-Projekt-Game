using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // ✅ Needed for images!


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image dialogueImage; // ✅ UI Image (for changing pictures)
    public string[] lines;
    public Sprite[] images; // ✅ Image list (one per line)
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(true); // ✅ Make sure it starts hidden
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true); // ✅ Show the dialogue panel
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine()); // ✅ Start text typing effect
        UpdateDialogueImage(); // ✅ Update image for the first line
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine(); // ✅ Move to the next line AND image
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index]; // ✅ Show full text immediately
            }
        }
    }

    IEnumerator TypeLine()
    {
        textComponent.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine()); // ✅ Start typing next line
            UpdateDialogueImage(); // ✅ Change the image
        }
        else
        {
            GameObject.FindGameObjectWithTag("DialogueBoxMain").SetActive(false); // ✅ Hide dialogue when done
        }
    }

   void UpdateDialogueImage()
{
    Debug.Log($"🔄 Updating Image | Index: {index} | images.Length: {images.Length}"); // ✅ Check if function runs

    if (index < images.Length && images[index] != null)
    {
        Debug.Log($"✅ Changing image to: {images[index].name}"); // ✅ Log image name
        dialogueImage.sprite = images[index]; // ✅ Assign image
        dialogueImage.gameObject.SetActive(true); // ✅ Show image
    }
    else
    {
        Debug.Log("❌ No image for this line, hiding image");
        dialogueImage.gameObject.SetActive(false); // ✅ Hide image if none exists
    }
}

}
