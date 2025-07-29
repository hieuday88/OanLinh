using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hours : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hours"))
        {
            ClockManager.Instance.isHours = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hours"))
        {
            ClockManager.Instance.isHours = false;
        }
    }
}
