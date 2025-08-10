using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : Singleton<ItemPlacer>
{
    public bool TryPlaceItem(int id, GameObject itemPrefab)
    {
        bool found = false;
        foreach (var item in IventoryManager.Instance.items)
        {
            if (item.id == id)
            {
                IventoryManager.Instance.RemoveItem(item);
                itemPrefab.SetActive(true);
                found = true;
                Debug.Log($"Placed item with ID: {id}");
                break;
            }
        }
        return found;
    }

}
