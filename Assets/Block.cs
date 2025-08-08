using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isFirst = false;
    public GameObject end;
    public GameObject guide;
    public Animator anim;
    void OnTriggerEnter(Collider other)
    {
        if (!isFirst)
        {
            guide.SetActive(true);
        }
        if (end.activeSelf)
            anim.enabled = true;


    }

    void OnTriggerExit(Collider other)
    {
        isFirst = true;
    }
}
