using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings Instance { get; set; }
    public static event Action OnSettingsReady;

    public RespawnManager RespawnManager { get; set; }
    public CameraManager CameraManager { get; set; }
    public LevelEndManager LevelEndManager { get; set; }


    private bool LevelSettingsDone = false;
    

    void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        if (!LevelSettingsDone 
            && RespawnManager != null 
            && CameraManager  != null
            && LevelEndManager != null)
        {
            LevelSettingsDone = true;
            OnSettingsReady?.Invoke();
            Debug.Log("Level settings done");
        }
    }
}
