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
            GameObject pipe = Instantiate(hair, pipeSpawn.position, Quaternion.identity);
            PipeManager.Instance.isWin = false;
            SetLayer(gameObject, LayerMask.NameToLayer("UI"));
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
