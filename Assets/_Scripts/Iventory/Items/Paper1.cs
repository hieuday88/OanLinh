using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class Paper1 : MonoBehaviour, IInteractable
{
   
    public Sprite image;
    public string title ;

    public void OnInteract()
    {
        var items = gameObject.GetComponent<ItemPickup>();
        if ((items != null && items.canInteract) || (items.item != null && IventoryManager.Instance.canUseItem))
        {
            PlayerInteraction.Instance.paperImage.sprite = image; 
            PlayerInteraction.Instance.paperImage.gameObject.SetActive(!PlayerInteraction.Instance.paperImage.gameObject
                .activeSelf);
            PlayerInteraction.Instance.isBusy = !PlayerInteraction.Instance.isBusy;
            IventoryManager.Instance.canUseItem = false;
        }
    }


    public string Infor()
    {
        return title;
    }
}
