using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button play;
    public Button settings;

    public Button exit;
    public Button back;

    void Awake()
    {
        play.onClick.AddListener(ButtonManager.Instance.OnPlayButtonClicked);
        settings.onClick.AddListener(ButtonManager.Instance.OnSettingsButtonClicked);
        exit.onClick.AddListener(ButtonManager.Instance.OnExitButtonClicked);
        back.onClick.AddListener(ButtonManager.Instance.OnBackButtonClicked);
        DontDestroyOnLoad(gameObject);
    }

}
