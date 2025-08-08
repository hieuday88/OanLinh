using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PasswordManager : Singleton<PasswordManager>
{
    [SerializeField] private string _password;

    public bool isWin = false;
    private Vector3 _lockInitialScale;
    public GameObject passwordObject;
    public TextMeshProUGUI wrongText;

    // Biến kiểm soát trạng thái rung
    private bool isShaking = false;

    public void CheckPassword(string password)
    {
        if (password == _password)
        {
            Debug.Log("Password is correct");
            isWin = true;
        }
        else
        {
            WrongPassword();
        }
    }

    public void WrongPassword()
    {
        if (isShaking) return;
        isShaking = true;
        isWin = false;

        // Kill tween cũ để tránh cộng dồn
        passwordObject.transform.DOKill();
        wrongText.transform.DOKill();

        // Lưu vị trí & scale ban đầu
        Vector3 originalPos = passwordObject.transform.localPosition;
        Vector3 originalScale = wrongText.transform.localScale;

        // Rung object
        passwordObject.transform
            .DOShakePosition(0.5f, new Vector3(10f, 0f, 0f), vibrato: 10, randomness: 90, snapping: false, fadeOut: true)
            .SetRelative(true)
            .OnComplete(() =>
            {
                passwordObject.transform.localPosition = originalPos; // Reset vị trí
                isShaking = false;
            });

        // Hiện text
        wrongText.enabled = true;
        wrongText.transform.localScale = Vector3.zero;

        wrongText.transform
            .DOScale(originalScale, 0.5f)
            .OnComplete(() =>
            {
                wrongText.transform.localScale = originalScale; // Reset scale gốc
                wrongText.enabled = false;
            });
    }


}