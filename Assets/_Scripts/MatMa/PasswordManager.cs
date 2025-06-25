using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    public static PasswordManager Instance;
    
    [SerializeField] private string _password;
    [SerializeField] private GameObject  _lock;
    public bool isWin = false;
    private Vector3 _lockInitialScale;

    private void Start()
    {
        _lockInitialScale = _lock.transform.localScale; // Lưu scale gốc
        _lock.SetActive(false); // Ẩn ban đầu (nếu cần)
    }

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    

    public void CheckPassword(string password)
    {
        if (password == _password)
        {
            Debug.Log("Password is correct");
            ShowLockSmooth();
            isWin = true;
        }
    }

    private void ShowLockSmooth()
    {
        _lock.SetActive(true);
        _lock.transform.localScale = Vector3.zero;
        _lock.transform.rotation = Quaternion.identity;

        Sequence s = DOTween.Sequence();

        // Xuất hiện mượt
        s.Append(_lock.transform.DOScale(_lockInitialScale, 1f).SetEase(Ease.OutBack));

        // Lắc sau khi hiện
        s.Append(_lock.transform.DOShakeRotation(
            duration:1f,
            strength: new Vector3(0, 0, 15),
            vibrato: 10,
            randomness: 50,
            fadeOut: true
        ));

        // Đợi 0.3 giây rồi tắt
        s.AppendInterval(5f);
        s.AppendCallback(() =>
        {
            _lock.SetActive(false);
            gameObject.SetActive(false);
        });
    }

    
    
}
