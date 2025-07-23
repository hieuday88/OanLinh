using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint4 : MonoBehaviour, IInteractable
{
    public string title;
    public int id;

    public Items item;

    public GameObject itemPrefab;

    public void OnInteract()
    {
        Debug.Log("1");
        if (ItemPlacer.Instance.TryPlaceItem(id, itemPrefab))
        {
            title = "Ổn rồi đó";
        }
        else
        {
            title = "Cần đặt gì đó vào đây";
        }
        Debug.Log("2");
    }

    public string Infor()
    {
        return title;
    }
}
