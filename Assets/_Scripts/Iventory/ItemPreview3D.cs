using UnityEngine;

public class ItemPreview3D : Singleton<ItemPreview3D>
{
    public Camera popupCamera;
    public Transform itemHolder;
   [SerializeField] private Vector3 originalScale = Vector3.one;
    public GameObject popupRoot;

    [SerializeField] private GameObject currentItem;
    private Vector3 lastMouse;
    private bool isDragging = false;

    void Update()
    {
        if (!popupRoot.activeSelf) return;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Luôn hiện chuột khi popup bật
        

        HandleItemRotation();

        // Đóng lại nếu ấn Space
        if (Input.GetKeyDown(KeyCode.E))
        {
            CloseItem();
        }
    }
    
    private void HandleItemRotation()
    {
        if (currentItem == null) return;

        float sensitivity = 0.15f;
        float minScale = 0.1f;
        float maxScale = 10f;

        var pickup = currentItem.GetComponent<ItemPickup>();
        bool isPaper = pickup != null && pickup.item != null && pickup.item.type == ItemType.Paper;

        // --- Xử lý xoay ---
        if (Input.GetMouseButton(0)) // giữ chuột trái để xoay
        {
            Vector3 delta = Input.mousePosition - lastMouse;

            if (isPaper)
            {
                itemHolder.Rotate(Vector3.forward, -delta.y * sensitivity, Space.Self);
            }
            else
            {
                itemHolder.Rotate(Vector3.up, -delta.x * sensitivity, Space.World);
                itemHolder.Rotate(Vector3.right, delta.y * sensitivity, Space.World);
            }
        }

        // --- Zoom bằng scale (trừ giấy) ---
        float scroll = Input.mouseScrollDelta.y;
        if ( Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 scale = currentItem.transform.localScale;

            // Tự tính zoomSpeed là 1/10 scale hiện tại từng trục
            float zoomX = scale.x * 0.1f;
            float zoomY = scale.y * 0.1f;
            float zoomZ = scale.z * 0.1f;

            scale.x = Mathf.Clamp(scale.x + scroll * zoomX,scale.x *minScale, scale.x*maxScale);
            scale.y = Mathf.Clamp(scale.y + scroll * zoomY, scale.y  * minScale,scale.y * maxScale);
            scale.z = Mathf.Clamp(scale.z + scroll * zoomZ, scale.z * minScale,scale.z * maxScale);

            currentItem.transform.localScale = scale;
        }

        lastMouse = Input.mousePosition;
    }


    

    public void ShowItem(GameObject prefab)
    {
        CloseItem();

        popupRoot.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        currentItem = PoolingManager.Spawn(prefab, itemHolder.position, Quaternion.identity);
        currentItem.transform.SetParent(itemHolder);

        if (currentItem.GetComponent<ItemPickup>()?.item?.type == ItemType.Paper)
        {
            currentItem.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            currentItem.transform.localRotation = Quaternion.identity;
        }

        currentItem.transform.localPosition = Vector3.zero;
        originalScale = currentItem.transform.localScale;
        currentItem.transform.localScale = originalScale;

        // 🟢 Lưu lại scale gốc
        

        SetLayerRecursively(currentItem.transform, LayerMask.NameToLayer("Item3D"));
        IventoryManager.Instance.isTake = false;
    }

    
    public void CloseItem()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (currentItem != null)
        {
            // 🟢 Reset lại scale về ban đầu
            currentItem.transform.localScale = originalScale;

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
