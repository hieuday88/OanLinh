using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Doll : MonoBehaviour, IInteractable, ISaveable
{
    public string title;
    public GameObject nu;
    private bool firstTime = false;

    public void OnInteract()
    {
        if (firstTime)
        {
            return;
        }

        nu.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.Instance.horror2);
        DOVirtual.DelayedCall(0.5f, () =>
        {
            nu.SetActive(false);
            firstTime = true;
        });
        GetComponent<ItemPickup>().Pickup();
    }

    public string Infor()
    {
        return title;
    }

    public object CaptureState()
    {
        return firstTime;
    }


    public void RestoreState(object state)
    {

        this.firstTime = (bool)state;
    }
}
