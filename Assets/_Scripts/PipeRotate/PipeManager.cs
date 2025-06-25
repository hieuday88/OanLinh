using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipeManager : MonoBehaviour
{
    [SerializeField] List<Pipe> pipeList = new List<Pipe>();
    private bool isWin = false;
    private bool effectStarted = false;

    [SerializeField] GameObject waterFall1;
    [SerializeField] GameObject waterFall2;

    void Update()
    {
        CheckPipe();
    }

    private void CheckPipe()
    {
        if (isWin || effectStarted) return;

        if ((pipeList[0]._rate == 1 || pipeList[0]._rate == 3) &&
            pipeList[1]._rate == 3 &&
            (pipeList[2]._rate == 3 || pipeList[2]._rate == 2) &&
            pipeList[3]._rate == 2 &&
            (pipeList[5]._rate == 1 || pipeList[5]._rate == 3) &&
            pipeList[6]._rate == 3 &&
            (pipeList[7]._rate == 0 || pipeList[7]._rate == 2) &&
            (pipeList[8]._rate == 3 || pipeList[8]._rate == 0))
        {
            isWin = true;
            effectStarted = true;
            foreach (Pipe pipe in pipeList)
            {
                pipe._active = false;
            }
            StartCoroutine(WinSequence());
        }
    }

    private IEnumerator WinSequence()
    {

        // 1. WaterFall1 xuất hiện bằng cách scale từ trên xuống
        waterFall1.SetActive(true);

        Vector3 originalScale1 = waterFall1.transform.localScale;
        waterFall1.transform.localScale = new Vector3(originalScale1.x, 0f, originalScale1.z);

        waterFall1.transform.DOScaleY(originalScale1.y, 1f).SetEase(Ease.OutQuart);

        // 2. Trong lúc đợi, sáng từng ống 1 theo thứ tự
        int[] order = { 0, 3, 4, 1, 2, 5, 8, 7, 6 };
        for (int i = 0; i < order.Length; i++)
        {
            pipeList[order[i]].EnableGlow(Color.cyan, 1f);
            yield return new WaitForSeconds(0.17f);
        }

        // 3. Sau đó WaterFall2 cũng xuất hiện như dòng nước
        yield return new WaitForSeconds(0.1f);

        waterFall2.SetActive(true);

        Vector3 originalScale2 = waterFall2.transform.localScale;
        waterFall2.transform.localScale = new Vector3(originalScale2.x, 0f, originalScale2.z);

        waterFall2.transform.DOScaleY(originalScale2.y, 1f).SetEase(Ease.OutQuart);
    }

}
