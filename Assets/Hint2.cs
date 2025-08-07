using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hint2 : MonoBehaviour, IInteractable
{
    public GameObject _doll1;
    public GameObject _doll2;
    public GameObject dark;
 
    public string hint;

    public GameObject hintText;

    public void OnInteract()
    {
        if (ItemPlacer.Instance.TryPlaceItem(7, _doll1))
        {
            if (_doll2.activeSelf)
            
                hintText.SetActive(false);
            dark.SetActive(false); 
            
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
