using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEditor.Rendering;
using UnityEngine;

public class End : MonoBehaviour, IInteractable
{
    public GameObject credit;

    public GameObject canvas;
    public void OnInteract()
    {
        credit.SetActive(true);
        canvas.SetActive(false);
        SoundManager.Instance.musicAudioSource.clip = SoundManager.Instance.musicClipOut;
        SoundManager.Instance.musicAudioSource.Play();
    }

    public string Infor()
    {
        return "Mình đây sao...";
    }

    public void BackToHome()
    {
        LoadSceneManager.Instance.LoadScene("MainMenu");
    }
}
