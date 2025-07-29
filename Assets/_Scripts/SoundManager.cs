using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;
    
    public AudioClip musicClip;
    public AudioClip clickClip;
    
    [Header("Doors")]
    public AudioClip openDoor;
    public AudioClip closeDoor;
    public AudioClip closeLightDoor;
    public AudioClip lockedDoor;
    
    [Header("Hint1")]
    public AudioClip knife;
    public AudioClip horror1;
    public AudioClip horror2;
    public AudioClip waterFall;
    public AudioClip keyFall;
    
    [Header("Finally")]
    public AudioClip woodFall;
    public AudioClip phoneRang;
    public AudioClip wind;
    public AudioClip ting;
    
    [Header("FlashBack")]
    public AudioClip runCar;

    void Start()
    {
        musicAudioSource.clip = musicClip;
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
        sfxAudioSource.loop = true;      // bật chế độ lặp
        sfxAudioSource.Play();
    }
    
    public void StopSFXLoop()
    {
        sfxAudioSource.loop = false;
        sfxAudioSource.Stop();
    }
    
}
