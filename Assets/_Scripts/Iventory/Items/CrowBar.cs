using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBar : MonoBehaviour, IInteractable, ISaveable
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


    public object CaptureState()
    {
        return gameObject.activeSelf;

    }

    public void RestoreState(object state)
    {

        this.gameObject.SetActive((bool)state);
    }

}