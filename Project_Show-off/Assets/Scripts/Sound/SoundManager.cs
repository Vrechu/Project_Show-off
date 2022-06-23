using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }


    public AudioSource MusicSource, EffectsSource;
    public AudioMixer Mixer;

    [Header("Effects")]
    public AudioClip Bite;
    public AudioClip Cheer, CheerAlt, Countdown, Fall, FallAlt, FruitHit, Jump, Push, Victory;

    [Header("Music")]
    public AudioClip IngameMusic;
    public AudioClip LoadingMusic, MainMenuMusic;

    [Header("Menu")]
    public AudioClip Return;
    public AudioClip Select, StartGame;

    public AudioClip[]PlayerSounds = new AudioClip[4];


    private void Awake()
    {
        GameInstanceManager.OnManagerDone += ManagerSetup;
    }

    private void OnDestroy()
    {
        GameInstanceManager.OnManagerDone -= ManagerSetup;
    }

    private void ManagerSetup()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    public void PlayEffect(AudioClip sound)
    {
        EffectsSource.PlayOneShot(sound);
    }

    public void PlayMusic(AudioClip music)
    {
        if (MusicSource.clip != music)
        {
            if (MusicSource.isPlaying)
            {
                MusicSource.Stop();
            }
            MusicSource.clip = music;
            MusicSource.Play();
        }
    }

    public void MuteMusic()
    {
        Mixer.SetFloat("MusicVolume", -80);
    }

    public void MuteEffects()
    {
        Mixer.SetFloat("EffectsVolume", -80);
    }

    public void UnmuteMusic()
    {
        Mixer.SetFloat("MusicVolume", 0);
    }

    public void UnmuteEffects()
    {
        Mixer.SetFloat("EffectsVolume", 0);
    }

}

