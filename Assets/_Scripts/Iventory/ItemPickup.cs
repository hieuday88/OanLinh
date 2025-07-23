using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items item;

    public bool canInteract = false;

    public void Pickup()
    {
        // Delete Item
        this.gameObject.SetActive(false);

        // Add item
        IventoryManager.Instance.AddItem(this.item);
    }
}
