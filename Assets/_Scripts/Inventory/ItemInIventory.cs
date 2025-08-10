using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemInIventory : MonoBehaviour
{
    public Items item;
    public GameObject prefab;

    public void SetItem(Items item)
    {
        this.item = item;
        this.prefab = item.prefab;
    }

    public void OnClick()
    {
        // Khi click thì gán prefab vào current
        Debug.Log("OnClick");
        IventoryManager.Instance.currItemPrefab = prefab;
        IventoryManager.Instance.isTake = true;
    }
}

