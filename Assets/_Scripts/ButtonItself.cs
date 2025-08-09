using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItself : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public void OnSettingsButtonClicked()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    
    public void OnBackButtonClicked()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
