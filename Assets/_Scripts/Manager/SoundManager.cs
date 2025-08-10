using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip musicClipIn;
    public AudioClip musicClipOut;
    public AudioClip credit;
    public AudioClip clickClip;

    [Header("Doors")]
    public AudioClip openDoor;
    public AudioClip closeDoor;
    public AudioClip closeLightDoor;
    public AudioClip lockedDoor;

    [Header("Hint1")]
    public AudioClip read;
    public AudioClip knife;
    public AudioClip horror1;
    public AudioClip horror2;
    public AudioClip waterFall;
    public AudioClip keyFall;
    public AudioClip La;
    public AudioClip baby;

    [Header("Finally")]
    public AudioClip woodFall;
    public AudioClip phoneRang;
    public AudioClip wind;
    public AudioClip ting;

    [Header("FlashBack")]
    public AudioClip runCar;

    public AudioClip crashCar;

    public void SetMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
    void Start()
    {
        musicAudioSource.clip = musicClipOut;
        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void ContinueMusic()
    {
        musicAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.loop = true;
        sfxAudioSource.Play();
    }

    public void StopSFXLoop()
    {
        sfxAudioSource.loop = false;
        sfxAudioSource.Stop();
    }

}
