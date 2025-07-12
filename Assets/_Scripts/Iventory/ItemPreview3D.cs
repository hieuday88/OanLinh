using UnityEngine;

public class ItemPreview3D : Singleton<ItemPreview3D>
{
    public Camera popupCamera;
    public Transform itemHolder;
    public GameObject popupRoot;

    [SerializeField] private GameObject currentItem;
    private Vector3 lastMouse;
    private bool isDragging = false;

    void Update()
    {
        if (!popupRoot.activeSelf) return;

        // Luôn hiện chuột khi popup bật
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bắt đầu xoay nếu chuột đang di chuyển
        if (currentItem != null && Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vector3 delta = Input.mousePosition - lastMouse;
            itemHolder.Rotate(Vector3.up, -delta.x * 0.5f, Space.World);
            itemHolder.Rotate(Vector3.right, delta.y * 0.5f, Space.World);
        }

        lastMouse = Input.mousePosition;

        // Đóng lại nếu ấn Space
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseItem();
        }
    }

    public void ShowItem(GameObject prefab)
    {
        CloseItem(); // clear trước

        popupRoot.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        currentItem = Instantiate(prefab, itemHolder.position, Quaternion.identity);
        currentItem.transform.SetParent(itemHolder);
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localRotation = Quaternion.identity;
        // currentItem.transform.localScale = Vector3.one;

        SetLayerRecursively(currentItem.transform, LayerMask.NameToLayer("Item3D"));
    }

    public void CloseItem()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (currentItem != null)
        {
            Destroy(currentItem);
            currentItem = null;
        }

        popupRoot.SetActive(false);
    }

    private void SetLayerRecursively(Transform t, int layer)
    {
        t.gameObject.layer = layer;
        foreach (Transform child in t)
        {
            SetLayerRecursively(child, layer);
        }
    }
}
