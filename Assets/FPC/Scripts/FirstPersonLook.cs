using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;
    [SerializeField] Transform flashlight;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Awake()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // if (PlayerInteraction.Instance.isBusy)
        // {
        //     frameVelocity = Vector2.zero;
        //     velocity = Vector2.zero;
        //     return;
        // }

        // Lấy sensitivity từ PlayerPrefs (nếu chưa set thì mặc định là 1f)
        float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2f);

        // Lấy mouse input
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Áp dụng sensitivity
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);

        // Làm mượt chuột
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Xoay camera theo trục dọc
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);

        // Xoay nhân vật theo trục ngang
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        // Xoay flashlight nếu có
        if (flashlight != null)
        {
            flashlight.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        }
    }

}
