using UnityEngine;
using UnityEngine.UI;

public class CustomVolumeBar : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Set slider theo giá trị lưu trước đó
        float volume = SoundManager.Instance.GetMusicVolume();
        volumeSlider.value = volume;

        // Gán sự kiện khi thay đổi slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        SoundManager.Instance.SetMusicVolume(volume);
    }
}