using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minutes : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Minutes"))
        {
            ClockManager.Instance.isMinutes = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Minutes"))
        {
            ClockManager.Instance.isMinutes = false;
        }
    }
}