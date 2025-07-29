using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    public string title;
    public GameObject dialogue;

    public Transform hint;

    void Start()
    {
        SoundManager.Instance.PlaySFXLoop(SoundManager.Instance.phoneRang);
    }
    
    public void OnInteract()
    {
        title = "Nghe điện thoại";
        SoundManager.Instance.StopSFXLoop();
        dialogue.SetActive(true);
        hint.localPosition = new Vector3(30, -33, -9);
    }

    public string Infor()
    {
        return title;
    }
}
