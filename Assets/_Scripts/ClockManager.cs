using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ClockManager : Singleton<ClockManager>,IInteractable
{
    public GameObject minutes;
    public GameObject hours;
    public GameObject players;
    public GameObject camera;
    public GameObject nap;
    public TextMeshProUGUI clockText;
    
    public bool isMinutes;
    public bool isHours;
    public bool isMove = true;
    
    private IInteractable _interactableImplementation;

    void Awake()
    {
        players = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && isMove)
        {
            minutes.transform.Rotate(Vector3.up, 1f);
        }

        if (Input.GetKey(KeyCode.D) && isMove)
        {
            hours.transform.Rotate(Vector3.up, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            players.SetActive(true);
            clockText.enabled = false;
            camera.SetActive(false);
        }

        if (isMinutes && isHours && isMove)
        {
            nap.layer = LayerMask.NameToLayer("Interactable");
            isMove = false;
            float tingDuration = SoundManager.Instance.ting.length;

            SoundManager.Instance.PlaySFX(SoundManager.Instance.ting);

            gameObject.transform
                .DOShakePosition(1.5f, 0.1f, 10, 90)
                .SetDelay(tingDuration) // Đợi âm thanh phát xong rồi mới rung
                .OnComplete(() =>
                {
                    clockText.enabled = false;
                    camera.SetActive(false);
                    players.SetActive(true);
                    SoundManager.Instance.PlaySFX(SoundManager.Instance.wind);

                    gameObject.transform.DOScale(Vector3.zero, 3f)
                        .SetEase(Ease.OutBack)
                        .OnComplete(() => {
                            gameObject.SetActive(false);
                        });
                });
            
        }
    }

    

    public void OnInteract()
    {
        camera.SetActive(true);
        clockText.enabled = true;
        players.SetActive(false);
    }

    public string Infor()
    {
        return "Đồng hồ";
    }
}
