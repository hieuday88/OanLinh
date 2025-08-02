using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class End : MonoBehaviour, IInteractable
{
    public GameObject credit;
    public void OnInteract()
    {
        credit.SetActive(true);
    }

    public string Infor()
    {
        return "Mình đây sao...";
    }
}
