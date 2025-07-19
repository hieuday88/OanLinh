using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public void OnPlayButtonClicked()
    {
        LoadSceneManager.Instance.LoadScene("Main");
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

