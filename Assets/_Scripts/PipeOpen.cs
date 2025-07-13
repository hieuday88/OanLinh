using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOpen : MonoBehaviour, IInteractable
{
    public GameObject pipeOpen;
    public Transform pipeSpawn;
    public GameObject hair;

    public void OnInteract()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pipeOpen.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || PipeManager.Instance.isWin)
        {
            ClosePipe();
        }
    }
    public void ClosePipe()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (PipeManager.Instance.isWin)
        {
            pipeOpen.SetActive(false);
            hair.SetActive(true);
            PipeManager.Instance.isWin = false;
            SetLayer(gameObject, LayerMask.NameToLayer("UI"));
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            pipeOpen.SetActive(false);
        }
    }
    public void SetLayer(GameObject obj, int newLayer)
    {
        if (obj != null)
            obj.layer = newLayer;
    }
    public string Infor()
    {
        return "PipeOpen";
    }
}
