using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixdistance : MonoBehaviour
{
    bool isFirst = false;

    public GameObject guide;
    void OnTriggerEnter(Collider other)
    {
        if (!isFirst)
        {
            guide.SetActive(true);
        }



    }

    void OnTriggerExit(Collider other)
    {
        isFirst = true;
    }
}
