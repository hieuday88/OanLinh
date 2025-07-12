using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item;
    private IInteractable interactableImplementation;

    public bool canInteract = false;

    void Pickup()
    {
        // Delete Item
        Destroy(this.gameObject);
        
        // Add item
        IventoryManager.Instance.AddItem(this.item);
    }

    void OnMouseDown()
    {
        if(PlayerInteraction.Instance.isPickup)
            Pickup();
    }

    

    
}
