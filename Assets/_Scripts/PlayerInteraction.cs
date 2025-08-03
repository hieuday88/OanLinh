using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


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

    public Volume volume;

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

            GameObject target = hit.collider.gameObject;
            IInteractable interactable = target.GetComponent<IInteractable>();

            if (interactable != null)
            {
                isPickup = true;
                crosshairImage.color = Color.white;
                crosshairImage.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                infoText.text = interactable != null ? interactable.Infor() : "Không thể tương tác";
                infoText.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Đã tương tác với: " + interactable.Infor());
                    if (interactable != null)
                    {
                        interactable.OnInteract();
                    }
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

    public void Jumpscare()
    {
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments.colorFilter.overrideState = true;
            colorAdjustments.colorFilter.value = Color.red;
        }
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.smoothness.value = 1f;
        }
        if (volume.profile.TryGet<VolFx.VhsVol>(out var vhs))
        {
            vhs._weight.value = 1f;
            vhs._rocking.value = 1f;
            vhs._noise.value = 0.5f;
            vhs._flickering.value = 0.5f;
        }

    }

    public void ResetScare()
    {
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments.colorFilter.overrideState = false;
        }
        if (volume.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.smoothness.value = 0f;

        }


        if (volume.profile.TryGet<VolFx.VhsVol>(out var vhs))
        {
            vhs._weight.value = 0.4f;
            vhs._bleed.value = 1.8f;
            vhs._rocking.value = 0;
            vhs._tape.value = 0.88f;
            vhs._noise.value = 0.274f;
            vhs._flickering.value = 0.1f;
            vhs._glitch.value = Color.red;
        }
    }


}
