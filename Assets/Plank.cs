using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Plank : MonoBehaviour, IInteractable
{
    public string title;

    public GameObject crowbar;

    public void OnInteract()
    {
        if (!crowbar.activeSelf)
        {
            title = "Gỡ bỏ";
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().enabled = false;
            SoundManager.Instance.PlaySFX(SoundManager.Instance.woodFall);
            DOVirtual.DelayedCall(3f, () =>
            {
                this.gameObject.SetActive(false);
            });
        }
        else
        {
            title = "Không thể gỡ ra";
        }
    }

    public string Infor()
    {
        return title;
    }
}
