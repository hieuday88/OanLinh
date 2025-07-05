using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemInIventory : MonoBehaviour
{
    public Items item;

    public void SetItem(Items item)
    {
        this.item = item;
    }

    public void OnClick()
    {
        // Khi click thì gán prefab vào current
        
        IventoryManager.Instance.currItemPrefab = item.prefab;
        IventoryManager.Instance.isTake = true;
    }
}

