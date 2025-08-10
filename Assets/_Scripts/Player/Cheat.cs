using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public Items[] items;
    void OnEnable()
    {
        foreach (var item in items)
        {
            IventoryManager.Instance.AddItem(item);
        }
    }

}
