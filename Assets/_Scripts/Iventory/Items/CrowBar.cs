using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBar : MonoBehaviour, IInteractable
{
    public string title;

    public void OnInteract()
    {
        
    }

    public string Infor()
    {
        return title;
    }
}
