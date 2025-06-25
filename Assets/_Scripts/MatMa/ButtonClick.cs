using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private string number;
    [SerializeField] private TextMeshProUGUI text;

    public Transform buttonTransform; // Kéo Button hoặc Image vào đây trong Inspector
    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = buttonTransform.localScale; // Lưu scale gốc
    }

    public void Click()
    {
        if (!PasswordManager.Instance.isWin)
        {
            // 1. Tạo hiệu ứng nhấn nút dựa trên scale gốc
            buttonTransform.DOKill(); // Hủy các tween đang chạy

            buttonTransform
                .DOScale(initialScale * 0.9f, 0.05f) // Giảm 10% so với scale gốc
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    buttonTransform
                        .DOScale(initialScale, 0.1f) // Quay về scale gốc
                        .SetEase(Ease.OutBack);
                });

            // 2. Xử lý số nhập

            if (text.text.Length < 8 && number != "11" && number != "10")
            {
                
                text.text += number;
                return;
            }
            if (number == "10")
            {
                if (!string.IsNullOrEmpty(text.text))
                    text.text = text.text.Remove(text.text.Length - 1, 1);
                return;
            }
            if (number == "11")
            {
                PasswordManager.Instance.CheckPassword(text.text);
                text.text = ""; return;
            }
        }
    }

}
