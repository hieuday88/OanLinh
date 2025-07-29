using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject door;
    public GameObject block;
    void OnTriggerEnter(Collider other)
    {
        block.SetActive(false);
        SoundManager.Instance.PlaySFX(SoundManager.Instance.closeDoor);
        door.transform.localRotation = Quaternion.Euler(-180, 0, 0);
        door.layer = 8;
        gameObject.SetActive(false);
    }
}
