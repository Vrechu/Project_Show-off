using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlacePlayers : MonoBehaviour
{
    private RespawnManager respawnManager;
    public static event Action OnPlayerSpawn;

    private void Start()
    {
        LevelSettings.OnSettingsReady += SetManagers;
        LevelSettings.OnSettingsReady += InstantiatePlayers;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetManagers;
        LevelSettings.OnSettingsReady -= InstantiatePlayers;
    }

    private void SetManagers()
    {
        respawnManager = LevelSettings.Instance.RespawnManager;
    }

    public void InstantiatePlayers()
    {
        foreach (PlayerProfile playerProfile in PlayerManager.Instance.GetPlayerProfiles())
        {
            if (!playerProfile.InScene)
            {
                GameObject avatar = Instantiate(playerProfile.AvatarPrefab, respawnManager.MySpawnPoint(playerProfile.PlayerNumber), true);
                playerProfile.Avatar = avatar;
                avatar.GetComponent<PlayerProfileAccess>().PlayerProfile = playerProfile;
                playerProfile.InScene = true;                
            }
        }
        OnPlayerSpawn?.Invoke();
    }

}
