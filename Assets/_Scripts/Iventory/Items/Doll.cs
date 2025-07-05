using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour, IInteractable
{
    public string title;
    public void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    public string Infor()
    {
        return title;
    }
}
