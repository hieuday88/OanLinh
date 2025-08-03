using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint3 : MonoBehaviour, IInteractable
{

    public GameObject _doll1;
    public GameObject _doll2;
    public GameObject dark;
    public string hint;

    public GameObject hintText;

    public void OnInteract()
    {
        if (ItemPlacer.Instance.TryPlaceItem(8, _doll2))
        {
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
