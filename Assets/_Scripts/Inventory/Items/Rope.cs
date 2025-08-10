using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour, IInteractable
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
