using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    public GameObject mainMenu;
    public GameObject settingsMenu;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnPlayButtonClicked()
    {
        LoadSceneManager.Instance.LoadScene("Main");
        SoundManager.Instance.musicAudioSource.clip = SoundManager.Instance.musicClipIn;
        SoundManager.Instance.musicAudioSource.Play();
    }

    public void OnSettingsButtonClicked()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnBackButtonClicked()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}