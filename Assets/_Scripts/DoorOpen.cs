using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteractable
{

    public GameObject doorPassWord;
    public Transform holder;
    public GameObject hintUI;
    public GameObject door;
    public void OnInteract()
    {
        hintUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject currentItem = Instantiate(doorPassWord, holder.position, Quaternion.identity);

        currentItem.transform.SetParent(holder);
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.identity;
        currentItem.transform.localScale = currentItem.transform.localScale * 1.5f;
    }

    public void CloseDoorPassWord()
    {
        if (PasswordManager.Instance != null && PasswordManager.Instance.isWin)
        {
            Debug.Log("Door is opened");
            var rotation = door.transform.localRotation;
            rotation.z = -99f;
            door.transform.localRotation = rotation;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hintUI.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) ||
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
