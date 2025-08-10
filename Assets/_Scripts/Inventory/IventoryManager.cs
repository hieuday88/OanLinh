using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IventoryManager : Singleton<IventoryManager>
{
    public List<Items> items = new List<Items>();
    
    public Transform itemHolder;
    public GameObject itemPrefab;
    
    public Items currentItem;
    public GameObject currItemPrefab;
    public bool isTake = false;
    public bool isTaking = false;
    public bool isUseItem = false;
    public bool canUseItem = false;
    public bool first = false;
    public GameObject guide;

    private void Update()
    {
        if(currItemPrefab == null)
            isTaking = false;
        else
        {
            isTaking = true;
        }
    }

    public GameObject GetItemPrefab()
    {
        return currItemPrefab;
    }

    public void AddItem(Items item)
    {
        items.Add(item);
        currentItem = item;
        DisplayItems();

        if (!first)
        {
            guide.SetActive(true);

            DOVirtual.DelayedCall(2f, () =>
            {
                first = true;
            });
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        currItemPrefab = prefab;
    }

    public Items GetCurrentItem()
    {
        return currentItem;
    }

    public void DisplayItems()
    {
        foreach (Transform itemPos in itemHolder)  
            Destroy(itemPos.gameObject);
        
        foreach (var item in items)
        {
            GameObject itemObject = Instantiate(itemPrefab, itemHolder);
            
            var itemName = itemObject.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemImage = itemObject.transform.Find("ItemImage").GetComponent<Image>();
            
            itemName.text = item.name;
            itemImage.sprite = item.image;

            var itemUI = itemObject.GetComponent<ItemInIventory>();
            itemUI.SetItem(item);
        }
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
        DisplayItems();
    }
}
