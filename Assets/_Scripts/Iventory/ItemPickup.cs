using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Items item;
    private IInteractable interactableImplementation;

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

    public void OnInteract()
    {
       
    }

    public string Infor()
    {
        return "Đồ vật";
    }
}
