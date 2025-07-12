using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOpen : MonoBehaviour, IInteractable
{
    public GameObject pipeOpen;
    public Transform holder;
    public void OnInteract()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject currentItem = Instantiate(pipeOpen, holder.position, Quaternion.identity);
        
        currentItem.transform.SetParent(holder);
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.identity;
    }

    public string Infor()
    {
        return "PipeOpen";
    }
}
