using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter(Collider other)
    {
        door.transform.localRotation = Quaternion.Euler(-180, 0, 0);
        door.layer = 8;
        gameObject.SetActive(false);
    }
}
