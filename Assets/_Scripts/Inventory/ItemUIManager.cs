using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemUIManager : Singleton<ItemUIManager>
{
    public GameObject openPrefab;
    public GameObject openBtn;
    public GameObject pause;
    public GameObject setting;
    public FirstPersonLook firstLook;
    public Rigidbody rb;
    [SerializeField] public bool isOpen = false;

    private RectTransform rectTrans;
    private Vector2 hiddenPos = new Vector2(0, -800); // vị trí ẩn bên dưới
    private Vector2 shownPos = new Vector2(-300, 0);         // vị trí hiển thị

    public bool isSettingOpen = false;


    private void Start()
    {
        rectTrans = openPrefab.GetComponent<RectTransform>();

        openPrefab.SetActive(false);
        rectTrans.anchoredPosition = hiddenPos;
        openPrefab.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OpenInventory();

        if (Input.GetKeyDown(KeyCode.Tab) && !PlayerInteraction.Instance.isBusy)
        {
            if (!isSettingOpen)
            {
                pause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                firstLook.enabled = false;
                rb.isKinematic = true;
                isSettingOpen = true;
                Debug.Log("Mo pause menu");
            }
        }
    }


    public void Continue()
    {
        pause.SetActive(!pause.activeSelf);
        // Ẩn chuột và khóa trong game (ví dụ FPS)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstLook.enabled = true;
        rb.isKinematic = false;
        isSettingOpen = false;
    }

    public void Setting()
    {
        setting.SetActive(true);
        pause.SetActive(false);
    }

    public void OutSetting()
    {
        setting.SetActive(false);
        pause.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SoundManager.Instance.musicAudioSource.clip = SoundManager.Instance.musicClipOut;
        SoundManager.Instance.musicAudioSource.Play();
    }
    public void OpenInventory()
    {
        // Nút nhấn hiệu ứng scale
        PlayerInteraction.Instance.isBusy = true;
        openBtn.transform.DOKill();
        openBtn.transform.DOScale(0.8f, 0.1f).OnComplete(() =>
        {
            openBtn.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        });

        // Toggle UI
        if (isOpen)
        {
            isOpen = false;
            PlayerInteraction.Instance.isBusy = false;
            // Scale nhỏ và trượt ra → sau đó ẩn
            openPrefab.transform.DOScale(0f, 0.2f);
            rectTrans.DOAnchorPos(hiddenPos, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
            {
                openPrefab.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            });
        }
        else
        {
            isOpen = true;

            // Bật trước để hiển thị
            openPrefab.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            openPrefab.transform.localScale = Vector3.zero;
            rectTrans.anchoredPosition = hiddenPos;

            // Trượt lên + scale mượt
            rectTrans.DOAnchorPos(shownPos, 0.3f).SetEase(Ease.OutBack);
            openPrefab.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
        }

        IventoryManager.Instance.DisplayItems();
    }

    public void CloseInventory()
    {
        isOpen = false;

        // Scale nhỏ và trượt ra → sau đó ẩn
        openPrefab.transform.DOScale(0f, 0.2f);
        rectTrans.DOAnchorPos(hiddenPos, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            openPrefab.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        });
        IventoryManager.Instance.DisplayItems();
    }

}