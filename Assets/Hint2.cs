using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hint2 : MonoBehaviour, IInteractable
{
    public Items doll1;
    public GameObject doll_1;

    public GameObject _doll1;
    public GameObject _doll2;
    public GameObject dark;
    public string hint;

    public GameObject hintText;

    public void OnInteract()
    {
        if (!doll_1.activeSelf)
        {
            _doll1.SetActive(true);
            IventoryManager.Instance.RemoveItem(doll1);
            if (_doll2.activeSelf)
                dark.SetActive(false);
            hintText.SetActive(false);
        }
        else
        {
            hint = "Cần đặt gì đó vào đây";
        }
    }

    public string Infor()
    {
        return hint;
    }
}
