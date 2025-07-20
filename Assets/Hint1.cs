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

        // Tạo danh sách tạm để chứa các item cần xóa
        List<Items> itemsToRemove = new List<Items>();

        foreach (var item in IventoryManager.Instance.items)
        {
            if (item.id == 13)
            {
                rope.SetActive(true);
                itemsToRemove.Add(item);
            }
            else if (item.id == 10)
            {
                doll32.SetActive(true);
                itemsToRemove.Add(item);
            }
        }

        // Sau khi duyệt xong, mới xóa các item khỏi inventory
        foreach (var item in itemsToRemove)
        {
            IventoryManager.Instance.RemoveItem(item);
        }
    }

    public string Infor()
    {
        return "Cần phải làm gì đó ở đây";
    }
}
