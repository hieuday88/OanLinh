using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
     [Header("Camera & Player")]
    public Transform camera; // Camera thật
    public FirstPersonLook look;
    public Rigidbody rb;
    public GameObject player; // Object chứa camera

    [Header("Target Focus")]
    public Transform target;
    public Vector3 cameraOffset = new Vector3(0, 2f, -5f); // Camera đứng cách target

    
    [Header("Timing")]
    public float moveDuration = 1f;
    public float stayDuration = 2f;
    
    private bool isFocusing = false;

    // public void Awake()
    // {
    //     camera = Camera.main.transform;
    // }

    public void TranCamera(Action onFinish = null)
    {
        if (isFocusing) return;
        isFocusing = true;
        rb.isKinematic = true;
        
         look.enabled = false;
        

        // Tính vị trí camera cần đến
        Vector3 targetCamPos = target.position + target.TransformDirection(cameraOffset);

        // Tính hướng nhìn từ camera mới đến target
        Vector3 lookDir = target.position - targetCamPos;

        // Góc cần xoay (Euler)
        Vector3 targetEulerAngles = Quaternion.LookRotation(lookDir).eulerAngles;

        // Fix hiện tượng giật: giới hạn góc quay tránh nhảy từ 350 -> 10 độ
        Vector3 currentEuler = camera.transform.eulerAngles;
        targetEulerAngles = new Vector3(
            Mathf.DeltaAngle(currentEuler.x, targetEulerAngles.x) + currentEuler.x,
            Mathf.DeltaAngle(currentEuler.y, targetEulerAngles.y) + currentEuler.y,
            Mathf.DeltaAngle(currentEuler.z, targetEulerAngles.z) + currentEuler.z
        );
        

        // Dừng tween cũ nếu có
        player.transform.DOKill();
        camera.transform.DOKill();

        // Di chuyển player
        player.transform.DOMoveX(targetCamPos.x, moveDuration).SetEase(Ease.InOutSine);
        player.transform.DOMoveZ(targetCamPos.z, moveDuration).SetEase(Ease.InOutSine);

        // Xoay camera bằng Euler angles
        player.transform.DORotate(targetEulerAngles, moveDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                // Gán lại chính xác góc cuối cùng bằng Euler để tránh sai số
                player.transform.localRotation = Quaternion.Euler(targetEulerAngles);
                player.transform.localRotation = Quaternion.Euler(targetEulerAngles); // CHÚ Ý dùng localRotation nếu dùng DOLocalRotate

                DOVirtual.DelayedCall(stayDuration, () =>
                {
                    if (look != null) look.enabled = true;
                    rb.isKinematic = false;
                    isFocusing = false;
                    onFinish?.Invoke();
                });
            });
    }


    public void ResetCamera()
    {
        
    }
}
