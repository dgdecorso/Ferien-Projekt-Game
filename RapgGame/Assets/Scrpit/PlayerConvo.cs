using UnityEngine;

public class PlayerConvo : MonoBehaviour
{
    public Transform InteractorSource; // Assign Main Camera in Inspector
    public float InteractRange = 2f;

    void Start()
    {
        if (InteractorSource == null) InteractorSource = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E ))
        {
            Debug.Log("E Clicked");
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }

            }
        }
    }

    public bool CanInteract()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, InteractRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactObj))
            {
                return true; // Player is near an NPC
            }
        }
        return false; // No NPC nearby
    }
}
