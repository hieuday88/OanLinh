using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IInteractable
{
    public GameObject lightObject;
    public void OnInteract()
    {
        lightObject.SetActive(!lightObject.activeSelf);
        this.gameObject.SetActive(false);
    }

    public string Infor()
    {
        return "Nhấn [E] để nhặt đèn pin";
    }
}
