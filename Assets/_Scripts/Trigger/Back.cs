using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Back : MonoBehaviour
{
    public GameObject doll1;
    public GameObject doll2;
    public GameObject doll3;
    public GameObject paper;
    public GameObject hint3;
    public FirstPersonLook look;
    public Rigidbody rb;
    public GameObject player;
    public Quaternion rotation;


    void OnTriggerExit(Collider other)
    {
        if (doll1.activeSelf && doll2.activeSelf && doll3.activeSelf)
        {
            EffectDollSuper();
            // paper.SetActive(true);
            // doll1.SetActive(false);
            // doll2.SetActive(false);
            // doll3.SetActive(false);
            // hint3.SetActive(false);
            hint3.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("Đã tắt");
        }
        else
        {
            Debug.Log("Không đủ điều kiện để tắt");
        }
    }

    public void EffectDollSuper()
    {
        float upDistance = 0.3f;
        float upTime = 1f;
        float scaleDownTime = 0.7f;
        float paperScaleTime = 0.4f;
        float paperFallTime = 0.8f;

        //PlayerInteraction.Instance.StartFlashbackStrongNoise();
        PlayerInteraction.Instance.ResetScare();
        Vector3 pos = gameObject.transform.position + new Vector3(0, 0, 0.60f);
        Debug.Log(pos);
        pos.y -= 1f;
        player.transform.position = pos;
        player.transform.rotation = rotation;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        look.enabled = false;
        rb.isKinematic = true;

        DOVirtual.DelayedCall(1f, () =>
        {

            DOVirtual.DelayedCall(1f, () =>
            {
                SoundManager.Instance.PlaySFX(SoundManager.Instance.wind);
                // Doll 1
                DG.Tweening.Sequence seq1 = DOTween.Sequence();
                Vector3 originalPos1 = doll1.transform.position;

                seq1.Append(doll1.transform.DOMoveY(originalPos1.y + upDistance, upTime).SetEase(Ease.OutQuad))
                    .Append(doll1.transform.DOScale(Vector3.zero, scaleDownTime).SetEase(Ease.InBack));


                // Doll 2
                DG.Tweening.Sequence seq2 = DOTween.Sequence();
                Vector3 originalPos2 = doll2.transform.position;

                seq2.Append(doll2.transform.DOMoveY(originalPos2.y + upDistance, upTime).SetEase(Ease.OutQuad))
                    .Append(doll2.transform.DOScale(Vector3.zero, scaleDownTime).SetEase(Ease.InBack));


                // Dool 3
                DG.Tweening.Sequence seq3 = DOTween.Sequence();
                Vector3 originalPos3 = doll3.transform.position;

                seq3.Append(doll3.transform.DOMoveY(originalPos3.y + upDistance, upTime).SetEase(Ease.OutQuad))
                    .Append(doll3.transform.DOScale(Vector3.zero, scaleDownTime).SetEase(Ease.InBack));

                // Paper xuất hiện sau khi dolls biến mất
                paper.SetActive(true);
                Vector3 pos1 = paper.transform.localScale;
                paper.transform.localScale = Vector3.zero;
                Vector3 paperStartPos = paper.transform.position;
                Vector3 paperEndPos = paperStartPos + Vector3.up * 1f; // rơi xuống 1 đơn vị

                Sequence paperSeq = DOTween.Sequence();
                paperSeq.AppendInterval(upTime + scaleDownTime) // đợi doll bay + biến mất
                    .Append(paper.transform.DOScale(pos1, paperScaleTime).SetEase(Ease.OutBack))
                    .Join(paper.transform.DOMoveY(paperStartPos.y, paperFallTime).SetEase(Ease.InQuad));
            });
        });

        DOVirtual.DelayedCall(5f, () =>
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            look.enabled = true;
            rb.isKinematic = false;
        });

    }

}
