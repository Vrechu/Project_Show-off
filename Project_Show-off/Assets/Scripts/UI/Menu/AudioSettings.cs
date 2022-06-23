using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    public Toggle MusicToggle, EffectsToggle;


    public void SetMusic()
    {
        if (MusicToggle.isOn) SoundManager.Instance.UnmuteMusic();
        else SoundManager.Instance.MuteMusic();
    }

    public void SetEffects()
    {
        if (EffectsToggle.isOn) SoundManager.Instance.UnmuteEffects();
        else SoundManager.Instance.MuteEffects();
    }

}
