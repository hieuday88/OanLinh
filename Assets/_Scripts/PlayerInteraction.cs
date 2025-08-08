using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using Bloom = UnityEngine.Rendering.Universal.Bloom;
using Vignette = UnityEngine.Rendering.Universal.Vignette;



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
    private GameObject lastTarget = null;
    
    public bool isPlashBack = false;

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
                // Chỉ cập nhật UI khi khác vật cũ
                if (target != lastTarget)
                {
                    lastTarget = target;
                    infoText.text = interactable.Infor();
                    infoText.enabled = true;
                    crosshairImage.color = Color.white;
                    crosshairImage.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }

                isPickup = true;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Đã tương tác với: " + interactable.Infor());
                    interactable.OnInteract();
                }
                return; // tránh else phía dưới
            }
        }

        // Nếu không hit hoặc không phải interactable
        if (lastTarget != null)
        {
            lastTarget = null;
            infoText.enabled = false;
            crosshairImage.color = originalCrosshairColor;
            crosshairImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            isPickup = false;
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

    public void StartFlashbackStrongNoise()
    {
        // Màu tối phủ màn hình
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments.colorFilter.overrideState = true;
            colorAdjustments.colorFilter.value = new Color(5f, 5f, 5f); // gần đen
        }

        // Nhiễu mạnh
        if (volume.profile.TryGet<FilmGrain>(out var grain))
        {
            grain.type.overrideState = true;
            grain.type.value = FilmGrainLookup.Thin2;

            grain.intensity.overrideState = true;
            grain.intensity.value = 0.8f; // nhiễu mạnh

            grain.response.overrideState = true;
            grain.response.value = 1f;
        }

        // VHS nếu có
        if (volume.profile.TryGet<VolFx.VhsVol>(out var vhs))
        {
            vhs._weight.overrideState = true;
            vhs._weight.value = 1f;

            vhs._noise.overrideState = true;
            vhs._noise.value = 1f;

            vhs._flickering.overrideState = true;
            vhs._flickering.value = 0.5f;

            vhs._rocking.overrideState = true;
            vhs._rocking.value = 0.3f;
        }

        // Sau vài giây sẽ tự giảm hiệu ứng
        Invoke(nameof(FadeOutFlashback), 1f); // chờ 1 giây rồi fade
    }

    public void PlayOpenShake()
    {
        Transform cam = mainCam.transform; // Thường là Main Camera
        float shakeDuration = 1f;
        float shakeStrength = 0.3f;
        int vibrato = 20;
        // Reset trước khi rung để không chồng hiệu ứng
        cam.DOKill();
        Vector3 originalPos = cam.localPosition;
        SoundManager.Instance.PlaySFX(SoundManager.Instance.La);
        // Rung trong 1 giây
        cam.DOShakePosition(shakeDuration, shakeStrength, vibrato)
            .OnComplete(() =>
            {
                cam.localPosition = originalPos; // trả về đúng vị trí ban đầu
            });
    }

    public void FadeOutFlashback()
    {
        // Fade màu tối về sáng dần
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            DOTween.To(() => colorAdjustments.colorFilter.value.r, r =>
            {
                Color c = colorAdjustments.colorFilter.value;
                c.r = c.g = c.b = r;
                colorAdjustments.colorFilter.value = c;
            }, 1f, 2f); // từ đen -> trắng nhạt
        }

        // Fade nhiễu
        if (volume.profile.TryGet<FilmGrain>(out var grain))
        {
            DOTween.To(() => grain.intensity.value, x => grain.intensity.value = x, 0f, 2f);
        }

        // Fade VHS
        if (volume.profile.TryGet<VolFx.VhsVol>(out var vhs))
        {
            DOTween.To(() => vhs._weight.value, x => vhs._weight.value = x, 0f, 2f);
            DOTween.To(() => vhs._noise.value, x => vhs._noise.value = x, 0f, 2f);
            DOTween.To(() => vhs._flickering.value, x => vhs._flickering.value = x, 0f, 2f);
            DOTween.To(() => vhs._rocking.value, x => vhs._rocking.value = x, 0f, 2f);
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
