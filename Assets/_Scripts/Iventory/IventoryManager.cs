using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryManager : Singleton<IventoryManager>
{
    List<Items> items = new List<Items>();
    
    public void AddItem(Items item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            
        }
    }
}
