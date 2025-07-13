using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint1 : MonoBehaviour, IInteractable
{
    private bool firstTime = true;
    public GameObject firstMeet;
    public GameObject doll32;
    public GameObject rope;
    public void OnInteract()
    {
        if (firstTime)
        {
            firstMeet.SetActive(true);
            firstTime = false;
        }
        foreach (var item in IventoryManager.Instance.items)
        {
            if (item.id == 13)
            {
                rope.SetActive(true);
                IventoryManager.Instance.RemoveItem(item);
            }
            if (item.id == 10)
            {
                doll32.SetActive(true);
                IventoryManager.Instance.RemoveItem(item);
            }
        }
    }
    public string Infor()
    {
        return "Cần phải làm gì đó ở đây";
    }
}
