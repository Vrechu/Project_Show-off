using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings Instance { get; set; }
    public static event Action OnSettingsReady;

    public RespawnManager RespawnManager { get; set; }
    

    void Start()
    {
        Instance = this;
        Debug.Log("Level settings changed");
    }
    private void Update()
    {
        if (RespawnManager != null)
        {
            OnSettingsReady?.Invoke();
            Debug.Log("Level settings done");
        }
    }
}
