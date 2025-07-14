using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour, IInteractable
{
    public Items doll32;
    public void OnInteract()
    {
        IventoryManager.Instance.AddItem(doll32); ;
    }

    public string Infor()
    {
        return "Một mớ tóc rối bù";
    }
}
