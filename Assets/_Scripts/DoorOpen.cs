using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{

    public GameObject doorPassWord;
    // public Transform holder;
    // public GameObject hintUI;
    public GameObject door;
    public FirstPersonLook look;
    public Rigidbody rb;


    public GameObject block;
    public void OnInteract()
    {
        // hintUI.SetActive(true);
        PlayerInteraction.Instance.isBusy = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        look.enabled = false;
        rb.isKinematic = true;
        doorPassWord.SetActive(true);

    }

    public void CloseDoorPassWord()
    {
        if (PasswordManager.Instance != null && PasswordManager.Instance.isWin)
        {
            Debug.Log("Door is opened");
            var rotation = door.transform.localRotation;
            rotation.z = -99f;
            door.transform.localRotation = rotation;
            block.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        look.enabled = true;
        rb.isKinematic = false;
        doorPassWord.SetActive(false);
        PlayerInteraction.Instance.isBusy = false;

    }

    public void Update()
    {
        if (Input.GetMouseButton(1) ||
                (PasswordManager.Instance != null && PasswordManager.Instance.isWin))
        {
            CloseDoorPassWord();
        }
    }

    public string Infor()
    {
        return "Mở cửa";
    }
}
