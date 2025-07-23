using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject doll1;
    public GameObject doll2;
    public GameObject doll3;
    public GameObject paper;
    public GameObject hint3;
    void OnTriggerExit(Collider other)
    {
        if (doll1.activeSelf && doll2.activeSelf && doll3.activeSelf)
        {
            paper.SetActive(true);
            doll1.SetActive(false);
            doll2.SetActive(false);
            doll3.SetActive(false);
            hint3.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("Đã tắt");
        }
        else
        {
            Debug.Log("Không đủ điều kiện để tắt");
        }
    }
}
