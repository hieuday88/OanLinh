using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FirstMeet : MonoBehaviour
{
    public GameObject knife;
    public GameObject firstMeet;
    public GameObject dool31;
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        knife.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.Instance.knife);
        firstMeet.SetActive(true);
        animator.SetTrigger("i2");
        SoundManager.Instance.PlaySFX(SoundManager.Instance.horror1);
        dool31.SetActive(true);
        PlayerInteraction.Instance.isBusy = true;
        DOVirtual.DelayedCall(2f, () =>
        {
            PlayerInteraction.Instance.isBusy = false;
            firstMeet.SetActive(false);
            this.gameObject.SetActive(false);
        });
    }
}
