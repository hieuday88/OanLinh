using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour, IInteractable
{
    public string title;
    public int id;
    public GameObject _paper;
    public GameObject hint;

    private bool firstTime = true;

    public void OnInteract()
    {
        Debug.Log("1");
        if (ItemPlacer.Instance.TryPlaceItem(id, _paper))
        {
            title = "Đã đặt giấy vào đinh";
        }
        else
        {
            title = "Cần treo gì đó lên đinh";
            if (firstTime)
            {
                firstTime = false;
                hint.SetActive(true);
            }
        }
        Debug.Log("2");
    }

    public string Infor()
    {
        return title;
    }
}
