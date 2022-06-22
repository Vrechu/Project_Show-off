using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlayMusic(SoundManager.Instance.IngameMusic);
    }
}
