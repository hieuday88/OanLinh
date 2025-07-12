using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private bool hasActive = false;
    void Update()
    {
        // Xu ly hien vat the
        if (IventoryManager.Instance.isTake)
        {
            Observer.Notify("Hien vat the");
            
        }
        // Cat vat the
        if (ItemUIManager.Instance.isOpen && IventoryManager.Instance.isTaking)
        {
            Observer.Notify("Cat vat the");
            IventoryManager.Instance.isTaking = false;
        }
        // Dung vat the
        if (!ItemUIManager.Instance.isOpen && IventoryManager.Instance.isTaking && !IventoryManager.Instance.isUseItem)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                IventoryManager.Instance.canUseItem = true;
                Debug.Log("F");
                Observer.Notify("Dung vat pham");
            }
        }
    
        // Nem vat the
    }
    
    
}
