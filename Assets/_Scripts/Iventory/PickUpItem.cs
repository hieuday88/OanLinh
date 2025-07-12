using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject itempickedUpPrefab;
    private GameObject currentItemInHand;
    public News paperNew;

    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        Observer.AddObserver("Hien vat the", PickUpItemFromIventory);
        Observer.AddObserver("Cat vat the", PutThingAways);
        Observer.AddObserver("Dung vat pham", UseItems);
    }

    void OnDestroy()
    {
        Observer.RemoveListener("Hien vat the", PickUpItemFromIventory);
        Observer.RemoveListener("Cat vat the", PutThingAways);
        Observer.RemoveListener("Dung vat pham", UseItems);
    }

    public void PickUpItemFromIventory()
    {
        // Lấy prefab từ Inventory
        itempickedUpPrefab = IventoryManager.Instance.GetItemPrefab();
        if (itempickedUpPrefab != null)
        {
            Debug.Log(itempickedUpPrefab.name);
        }

        // Tạo bản sao tại vị trí tay
        //GameObject spawnedItem = Instantiate(itempickedUpPrefab, pos.position, Quaternion.identity);

        ItemPreview3D.Instance.ShowItem(itempickedUpPrefab);
        
        // Đóng Inventory + xóa khỏi danh sách
        ItemUIManager.Instance.CloseInventory();
        IventoryManager.Instance.RemoveItem(itempickedUpPrefab.GetComponent<ItemPickup>().item);
        IventoryManager.Instance.isTake = false;
    }
    public void PutThingAways()
    {
        ItemPreview3D.Instance.CloseItem();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        IventoryManager.Instance.AddItem(itempickedUpPrefab.GetComponent<ItemPickup>().item);
        IventoryManager.Instance.currItemPrefab = null;
        itempickedUpPrefab = null;
        Destroy(currentItemInHand);
        currentItemInHand = null;
    }

    public void UseItems()
    {
        if (currentItemInHand != null)
        {
            var item = currentItemInHand.GetComponent<ItemPickup>().item;
            if (item.type == ItemType.Paper)
            {
                UsePaper(item);
            }
            else if(item.type == ItemType.News)
            {
                UseNews(item);
            }
        }
    }

    public void UseNews(Items items)
    {
        var itemInfo = currentItemInHand.GetComponent<News>();
        itemInfo.OnInteract();
    }
    
    public void UsePaper(Items items)
    {
        var itemInfo = currentItemInHand.GetComponent<Paper1>();
        itemInfo.OnInteract();
    }

    public void UseCrowBar(Items items)
    {
        
    }
    
    public void UseKey(Items items)
    {
        
    }

    public void UseDoll(Items items)
    {
        
    }

    public void UseHair(Items items)
    {
        
    }
    
    public void UseCrop(Items items)
    {
        
    }
    
}
