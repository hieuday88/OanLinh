using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class Hint1 : MonoBehaviour, IInteractable
{
    private bool firstTime = true;
    public GameObject firstMeet;
    public GameObject doll32;
    public GameObject rope;

    public GameObject nu;
    public GameObject key;
    public GameObject Hint2;
    public GameObject Hint3;

    private string hintText = "";

    private bool haveDoll = false;
    private bool haveRope = false;

    public void OnInteract()
    {
        if (firstTime)
        {
            firstMeet.SetActive(true);
            firstTime = false;
            hintText = "Cần phải làm gì đó ở đây";
            DOVirtual.DelayedCall(2f, () =>
            {
                hintText = "";
            });
        }

        var ropeItem = IventoryManager.Instance.items.Find(item => item.id == 13);
        if (ropeItem != null && !haveRope)
        {
            rope.SetActive(true);
            IventoryManager.Instance.RemoveItem(ropeItem);
            haveRope = true;
        }

        var dollItem = IventoryManager.Instance.items.Find(item => item.id == 10);
        if (dollItem != null && haveRope && !haveDoll)
        {
            doll32.SetActive(true);
            IventoryManager.Instance.RemoveItem(dollItem);
            haveDoll = true;
            Enough();
        }
    }


    public string Infor()
    {
        return hintText;
    }

    void Enough()
    {
        if (haveDoll && haveRope)
        {
            nu.SetActive(true);
            SoundManager.Instance.PlaySFX(SoundManager.Instance.horror2);
            PlayerInteraction.Instance.Jumpscare();
            key.SetActive(true);
            doll32.SetActive(false);
            hintText = "Có gì đó vừa rơi xuống";
            DOVirtual.DelayedCall(0.5f, () =>
            {
                hintText = "";
                nu.SetActive(false);
                doll32.SetActive(true);
                gameObject.SetActive(false);
                Hint2.SetActive(true);
                Hint3.SetActive(true);
                PlayerInteraction.Instance.ResetScare();
            });

            DOVirtual.DelayedCall(2f, () =>
            {
                SoundManager.Instance.PlaySFX(SoundManager.Instance.keyFall);
            });


        }
    }
}
