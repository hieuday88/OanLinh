using DG.Tweening;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Góc cửa khi mở (local Euler angles)")]
    public Vector3 openRotation;
    public Vector3 closeRotation;

    [Header("Tốc độ xoay")]
    public float openSpeed = 10f;

    [Header("Trạng thái cửa")]
    public bool isOpen = false;
    public bool isLocked = true;  // 🔒 Thêm biến để khóa cửa

    private Quaternion targetRotation;
    private bool isShaking = false;

    void Start()
    {
        // Khi bắt đầu, đặt target là trạng thái đóng
        targetRotation = Quaternion.Euler(closeRotation);
        transform.localRotation = targetRotation;
    }

    void Update()
    {
        // Luôn xoay dần về targetRotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * openSpeed);

        // Nếu đã gần đúng góc, đặt chính xác để tránh rung
        if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.5f)
        {
            transform.localRotation = targetRotation;
        }
    }

    public void OpenDoor()
    {
        if (isLocked)
        {
            TryShake(); // 🔄 Nếu đang bị khóa thì không mở, chỉ rung
            Debug.Log($"{gameObject.name} is locked!");
            return;
        }

        if (isOpen) return;

        SoundManager.Instance.PlaySFX(SoundManager.Instance.openDoor);
        isOpen = true;
        
        targetRotation = Quaternion.Euler(openRotation);
        Debug.Log($"{gameObject.name} is opening...");
    }

    public void CloseDoor()
    {
        if (!isOpen) return;

        SoundManager.Instance.PlaySFX(SoundManager.Instance.closeLightDoor);
        isOpen = false;
        isLocked = false;
        targetRotation = Quaternion.Euler(closeRotation);
        Debug.Log($"{gameObject.name} is closing...");
    }

    public void ToggleDoor()
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor(); // 🚪 Gọi OpenDoor sẽ xử lý tự rung nếu đang khóa
    }

    void TryShake()
    {
        if (isShaking) return;

        isShaking = true;
        SoundManager.Instance.PlaySFX(SoundManager.Instance.lockedDoor);

        float originalZ = transform.localEulerAngles.z;

        // Rung chỉ trục Z, giữ nguyên X và Y
        DOTween.To(
                () => originalZ,
                z => transform.localEulerAngles = new Vector3(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y, z),
                originalZ + 2f, // lệch nhẹ 2 độ
                0.05f
            )
            .SetLoops(4, LoopType.Yoyo)
            .SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                transform.localRotation = targetRotation; // Reset về góc chuẩn
                isShaking = false;
            });
    }


}
