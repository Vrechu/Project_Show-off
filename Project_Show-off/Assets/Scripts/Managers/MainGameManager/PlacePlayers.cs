using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacePlayers : MonoBehaviour
{
    private RespawnManager respawnManager;
    private void Start()
    {
        LevelSettings.OnSettingsReady += SetSpawnManager;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetSpawnManager;
    }

    private void SetSpawnManager()
    {
        respawnManager = LevelSettings.Instance.RespawnManager;
    }

    public void InstantiatePlayers()
    {
        foreach (PlayerProfile playerProfile in PlayerManager.Instance.GetPlayerProfiles())
        {
            if (!playerProfile.InScene)
            {
                GameObject avatar = Instantiate(playerProfile.GetAvatar(), respawnManager.MySpawnPoint(playerProfile.Number));
                avatar.GetComponent<PlayerProfileAccess>().PlayerProfile = playerProfile;
                playerProfile.InScene = true;
            }
        }
    }

}
