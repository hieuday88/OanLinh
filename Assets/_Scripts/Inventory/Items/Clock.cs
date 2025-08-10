using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    [Header("Needles")]
    public Transform shortNeedle;
    public Transform longNeedle;

    [Header("Camera Focus")]
    public Transform cameraTarget;
    public float cameraMoveDuration = 1.2f;
    public Ease cameraEase = Ease.InOutSine;


    [Header("Rotation Settings")]
    public float rotateDuration = 0.3f;

    public float shortAngle = 0f;
    public float longAngle = 0f;

    private bool isInteracting = false;
    public bool isOpen = false;

    private Vector3 originalCamPosition;
    private Quaternion originalCamRotation;

    private bool isLocked = false;


    public void OnInteract()
    {
        if (isInteracting) return;

        DOVirtual.DelayedCall(1f, () =>
        {
            isInteracting = true;
            isLocked = true;
        });
        PlayerInteraction.Instance.isBusy = true;

        Transform cam = Camera.main.transform;

        originalCamPosition = cam.position;
        originalCamRotation = cam.rotation;

        cam.DOMove(cameraTarget.position, cameraMoveDuration).SetEase(cameraEase);
        cam.DORotateQuaternion(cameraTarget.rotation, cameraMoveDuration).SetEase(cameraEase);

    }

    void Update()
    {
        if (!isInteracting) return;

        // Xoay kim giờ
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shortAngle -= 30f;
            RotateNeedle(shortNeedle, shortAngle);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            shortAngle += 30f;
            RotateNeedle(shortNeedle, shortAngle);
        }

        // Xoay kim phút
        if (Input.GetKeyDown(KeyCode.A))
        {
            longAngle -= 30f;
            RotateNeedle(longNeedle, longAngle);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            longAngle += 30f;
            RotateNeedle(longNeedle, longAngle);
        }

        // Kiểm tra mở khóa nếu đúng giờ
        if (!isOpen &&
            Mathf.Approximately(shortAngle % 360, -30f % 360) &&
            Mathf.Approximately(longAngle % 360, -90f % 360))
        {
            isOpen = true;
            Debug.Log("Đã mở khóa đồng hồ!");
        }

        if (Input.GetKeyDown(KeyCode.V))
            ExitInteraction();
    }

    void RotateNeedle(Transform needle, float angle)
    {
        needle.DOLocalRotate(new Vector3(0, angle, 0), rotateDuration).SetEase(Ease.OutQuad);
    }

    public string Infor()
    {
        return "Nhấn E/Q để xoay kim giờ, A/D để xoay kim phút";
    }

    void ExitInteraction()
    {
        isInteracting = false;

        PlayerInteraction.Instance.isBusy = false;

        isLocked = false;

        // Camera bay về vị trí cũ
        Transform cam = Camera.main.transform;

        cam.DOMove(originalCamPosition, cameraMoveDuration).SetEase(cameraEase);
        cam.DORotateQuaternion(originalCamRotation, cameraMoveDuration).SetEase(cameraEase);

        // Nếu có controller, bật lại ở đây (nếu bạn dùng hệ thống riêng)
        // PlayerController.Instance.enabled = true;
    }

    void LateUpdate()
    {
        if (isLocked)
        {
            Transform cameraTransform = Camera.main.transform;
            cameraTransform.position = cameraTarget.position;
            cameraTransform.rotation = cameraTarget.rotation;
        }
    }

}
