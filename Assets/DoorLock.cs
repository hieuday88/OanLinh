using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    private bool isLock = false;
    public Transform door;
    void OnTriggerEnter(Collider other)
    {
        if (isLock)
            return;
        door.localRotation = Quaternion.Euler(-180, 0, 0);
        isLock = true;
    }
}
