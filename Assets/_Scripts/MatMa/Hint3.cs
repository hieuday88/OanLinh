using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Sequence = Unity.VisualScripting.Sequence;

public class Hint3 : MonoBehaviour, IInteractable
{

    public GameObject _doll1;
    public GameObject _doll2;
    public GameObject dark;
    public string hint;

    public GameObject hintText;

    public void OnInteract()
    {
        if (ItemPlacer.Instance.TryPlaceItem(8, _doll2))
        {
            if (_doll1.activeSelf)
            {
                dark.SetActive(false);
                Effect();
                hintText.SetActive(false);
            }
            
        }
        else
        {
            hint = "Cần đặt gì đó vào đây";
        }
    }

    public string Infor()
    {
        return hint;
    }
    
    public void Effect()
    {
        float upDistance = 0.5f;
        float upTime = 0.5f;
        float shakeTime = 1f; // Giảm thời gian rung để giật mạnh
        float downTime = 0.2f;
        float shakeStrength = 1f; // Tăng độ mạnh rung
        int vibrato = 50; // Tăng số lần rung

        // Doll 1
        DG.Tweening.Sequence seq1 = DOTween.Sequence();
        Vector3 originalPos1 = _doll1.transform.position;

        seq1.Append(_doll1.transform.DOMoveY(originalPos1.y + upDistance, upTime).SetEase(Ease.OutQuad))
            .Append(_doll1.transform.DOShakePosition(shakeTime, new Vector3(0f, 0f, shakeStrength), vibrato))
            .Append(_doll1.transform.DOMoveY(originalPos1.y, downTime).SetEase(Ease.InQuad));

        // Doll 2
        DG.Tweening.Sequence seq2 = DOTween.Sequence();
        Vector3 originalPos2 = _doll2.transform.position;

        seq2.Append(_doll2.transform.DOMoveY(originalPos2.y + upDistance, upTime).SetEase(Ease.OutQuad))
            .Append(_doll2.transform.DOShakePosition(shakeTime, new Vector3(0f, 0f, shakeStrength), vibrato))
            .Append(_doll2.transform.DOMoveY(originalPos2.y, downTime).SetEase(Ease.InQuad));

        DOVirtual.DelayedCall(1f, () =>
        {
            PlayerInteraction.Instance.PlayOpenShake();
        }); 
        
        PlayerInteraction.Instance.Jumpscare();
        DOVirtual.DelayedCall(1f, () =>
        {
            PlayerInteraction.Instance.Jumpscare();
            DOVirtual.DelayedCall(0.5f, () =>
            {
                PlayerInteraction.Instance.ResetScare();
            
            });
        }); 
    }
}
