using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : MonoBehaviour, IInteractable
{
    public GameObject hint2;
    public GameObject hint3;
    public void OnInteract()
    {

    }
    public string Infor()
    {
        return "Một bóng tối đặc quánh, không thể đi lên";
    }

    void OnDisable()
    {
        hint2.SetActive(false);
        hint3.SetActive(false);
    }
}
