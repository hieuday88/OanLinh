using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CabinetController : MonoBehaviour,IInteractable
{
    private IInteractable _interactableImplementation;

    [Header("Vị trí mở & đóng (local position)")]
    public Vector3 openPosition;
    public Vector3 closePosition;

    [Header("Tốc độ kéo (thời gian kéo)")]
    public float moveDuration = 0.5f;

    [Header("Trạng thái tủ")]
    public bool isOpen = false;

    private bool isMoving = false;
    

    void Start()
    {
        // Đảm bảo tủ ở trạng thái đóng khi bắt đầu
        transform.localPosition = closePosition;
    }

    public void ToggleDrawer()
    {
        if (isMoving) return;

        if (isOpen)
            CloseDrawer();
        else
            OpenDrawer();
    }

    public void OpenDrawer()
    {

        if (isOpen) return;

        isOpen = true;
        isMoving = true;

        //SoundManager.Instance.PlaySFX(SoundManager.Instance.openDrawer); // Bạn cần thêm âm thanh mở tủ
        transform.DOLocalMove(openPosition, moveDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => isMoving = false);
    }

    public void CloseDrawer()
    {
        if (!isOpen) return;

        isOpen = false;
        isMoving = true;

        //SoundManager.Instance.PlaySFX(SoundManager.Instance.closeDrawer); // Bạn cần thêm âm thanh đóng tủ
        transform.DOLocalMove(closePosition, moveDuration)
            .SetEase(Ease.InCubic)
            .OnComplete(() => isMoving = false);
    }

    

    public string title;
    public void OnInteract()
    {
        CabinetController drawer = GetComponent<CabinetController>();
        if (drawer != null)
        {
            title = "Mở tủ";
            drawer.ToggleDrawer();
            return;
        }
    }

    public string Infor()
    {
        return title;
    }
}
