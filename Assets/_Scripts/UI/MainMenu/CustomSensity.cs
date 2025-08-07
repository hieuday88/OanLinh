using UnityEngine;
using UnityEngine.UI;

public class CustomSensity : MonoBehaviour
{
    public Slider sensitySlider;

    void Start()
    {
        // Lấy độ nhạy từ PlayerPrefs, mặc định 1.0
        float sensity = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
        sensitySlider.value = sensity;

        // Gán sự kiện thay đổi
        sensitySlider.onValueChanged.AddListener(OnSensityChanged);
    }

    private void OnSensityChanged(float value)
    {
        // Lưu giá trị độ nhạy mới
        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }
}