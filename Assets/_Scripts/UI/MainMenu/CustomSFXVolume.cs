using UnityEngine;
using UnityEngine.UI;

public class CustomSFXVolume : MonoBehaviour
{
    public Slider sfxSlider;

    void Start()
    {
        // Lấy SFX volume từ SoundManager
        float volume = SoundManager.Instance.GetSFXVolume();
        sfxSlider.value = volume;

        // Gán sự kiện thay đổi slider
        sfxSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        SoundManager.Instance.SetSFXVolume(volume);
    }
}