using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class L : Pipe
{
    public void OnMouseDown()
    {
        if(_active)
            RotatePipe();
    }

    public override void RotatePipe()
    {
        mark++;
        mark %= 4;
        _rate = (_rate + 1) % 4;

        // Chỉ xoay trục X, giữ Y và Z = 0
        Vector3 targetRotation = new Vector3(_rate * 90f, 90f, -120f);

        transform
            .DOLocalRotate(targetRotation, 0.2f)
            .SetEase(Ease.OutBack);
    }
}
