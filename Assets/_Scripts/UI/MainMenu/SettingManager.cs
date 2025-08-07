using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider sensitivitySlider;

    // Lưu trữ giá trị cũ để khôi phục khi Cancel
    private float originalMusicVolume;
    private float originalSFXVolume;
    private float originalSensitivity;

    void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        // Lấy từ PlayerPrefs
        originalMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        originalSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        originalSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1f);

        // Cập nhật UI
        musicSlider.value = originalMusicVolume;
        sfxSlider.value = originalSFXVolume;
        sensitivitySlider.value = originalSensitivity;
    }

    public void ApplySettings()
    {
        // Gọi hàm lưu (nếu có)
        SoundManager.Instance.SetMusicVolume(musicSlider.value);
        SoundManager.Instance.SetSFXVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivitySlider.value);
        PlayerPrefs.Save();

        // Cập nhật lại các giá trị gốc
        originalMusicVolume = musicSlider.value;
        originalSFXVolume = sfxSlider.value;
        originalSensitivity = sensitivitySlider.value;
    }

    public void CancelSettings()
    {
        // Khôi phục lại giá trị ban đầu
        musicSlider.value = originalMusicVolume;
        sfxSlider.value = originalSFXVolume;
        sensitivitySlider.value = originalSensitivity;

        // Gọi lại set volume để cập nhật âm thanh đúng
        SoundManager.Instance.SetMusicVolume(originalMusicVolume);
        SoundManager.Instance.SetSFXVolume(originalSFXVolume);
        PlayerPrefs.SetFloat("MouseSensitivity", originalSensitivity);
    }
}