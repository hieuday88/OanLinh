using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBlock : MonoBehaviour, IInteractable
{
    public GameObject flashlight;
    public string text = "";
    public void OnInteract()
    {
        if (flashlight.activeSelf)
        {
            this.gameObject.SetActive(false);
            text = "";
        }
        else
            text = "Có vẻ bạn quên gì đó";

    }

    public string Infor()
    {
        return text;
    }
}
