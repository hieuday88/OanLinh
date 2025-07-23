using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint3 : MonoBehaviour, IInteractable
{
    public Items doll2;
    public GameObject doll_2;

    public GameObject _doll1;
    public GameObject _doll2;
    public GameObject dark;
    public string hint;

    public GameObject hintText;

    public void OnInteract()
    {
        if (!doll_2.activeSelf)
        {
            _doll2.SetActive(true);
            IventoryManager.Instance.RemoveItem(doll2);
            if (_doll1.activeSelf)
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
