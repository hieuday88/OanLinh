using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Góc cửa khi mở (local Euler angles)")]
    public Vector3 openRotation;
    public Vector3 closeRotation;

    [Header("Tốc độ xoay")]
    public float openSpeed = 10f;

    private bool isOpen = false;
    private Quaternion targetRotation;

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
        if (isOpen) return;
        isOpen = true;
        targetRotation = Quaternion.Euler(openRotation);
        Debug.Log($"{gameObject.name} is opening...");
    }

    public void CloseDoor()
    {
        if (!isOpen) return;
        isOpen = false;
        targetRotation = Quaternion.Euler(closeRotation);
        Debug.Log($"{gameObject.name} is closing...");
    }

    public void ToggleDoor()
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor();
    }
}