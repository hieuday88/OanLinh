using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        LoadSceneManager.Instance.LoadScene("Flashback");
    }
    public string Infor()
    {
        return "Có một ký ức mơ hồ ở đây";
    }
}
