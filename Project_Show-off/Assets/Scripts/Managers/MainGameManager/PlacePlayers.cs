using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacePlayers : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Start()
    {
        LevelSettings.OnSettingsReady += SetManagers;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetManagers;
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
                GameObject avatar = Instantiate(playerProfile.AvatarPrefab, respawnManager.MySpawnPoint(playerProfile.Number));
                playerProfile.avatar = avatar;
                avatar.GetComponent<PlayerProfileAccess>().PlayerProfile = playerProfile;
                playerProfile.InScene = true;
                //LevelSettings.Instance.CameraManager.SetCamera(playerProfile);
            }
        }
    }

}
