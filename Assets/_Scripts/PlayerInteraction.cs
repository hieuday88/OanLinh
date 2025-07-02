using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : Singleton<PlayerInteraction>
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public TextMeshProUGUI infoText;

    public GameObject desText;
    private Camera mainCam;

    public Image crosshairImage;

    private Color originalCrosshairColor;

    public bool isBusy = false;
    public bool isPickup = false;

    void Start()
    {
        mainCam = Camera.main;
        originalCrosshairColor = crosshairImage.color;
        if (infoText != null)
            infoText.enabled = false;
    }

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            isBusy = true;
            crosshairImage.color = Color.white;
            crosshairImage.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            GameObject target = hit.collider.gameObject;
            IInteractable interactable = target.GetComponent<IInteractable>();
            infoText.text = interactable != null ? interactable.Infor() : "Không thể tương tác";
            infoText.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Đã tương tác với: " + target.name);
                if (interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }
        else
        {   
            isPickup = false;
            if (infoText != null)
                infoText.enabled = false;
            crosshairImage.color = originalCrosshairColor;
            crosshairImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        }
    }
}
