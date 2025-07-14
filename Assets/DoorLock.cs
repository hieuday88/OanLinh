using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private bool isLock = false;
    public GameObject door;
    void OnTriggerEnter(Collider other)
    {
        if (isLock)
            return;
        door.transform.localRotation = Quaternion.Euler(-180, 0, 0);
        door.layer = 8;
        isLock = true;
    }
}
