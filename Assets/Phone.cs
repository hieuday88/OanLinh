using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    public string title;
    public GameObject dialogue;

    public Transform hint;

    public void OnInteract()
    {
        title = "Nghe điện thoại";
        dialogue.SetActive(true);
        hint.localPosition = new Vector3(30, -33, -9);
    }

    public string Infor()
    {
        return title;
    }
}
