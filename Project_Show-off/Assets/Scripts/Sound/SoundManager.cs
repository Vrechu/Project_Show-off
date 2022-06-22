using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }


    public AudioSource MusicSource, EffectsSource;

    [Header("Effects")]
    public AudioClip Bite;
    public AudioClip Cheer, CheerAlt, Countdown, Fall, FallAlt, FruitHit, Jump;

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
}

