using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Doll1 : MonoBehaviour, IInteractable
{
    public string title;
    public void OnInteract()
    {
        GetComponent<ItemPickup>().Pickup();
    }

    public string Infor()
    {
        return title;
    }
}
