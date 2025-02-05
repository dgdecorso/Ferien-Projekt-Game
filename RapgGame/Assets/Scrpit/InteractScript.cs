using UnityEngine;
using System.Collections.Generic;
using System.Collections;

interface IInteractable {
    public void Interact();
}

public class InteractScript : MonoBehaviour {


    public Transform InteractorSource;
    public float InteractRange;
    void Start() {
        
    }


    void Update() {
    if (InteractorSource == null) {
        Debug.LogWarning("InteractorSource was not set!");
        return;
    }

    if (Input.GetKeyDown(KeyCode.E)) {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        
        Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange, Color.red, 2f); // Debug ray

        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                interactObj.Interact();
            }
        }
    }
}
}