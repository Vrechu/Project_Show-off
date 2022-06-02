using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private RespawnManager respawnManager;
    private int playerNumber;

    private void Start()
    {
        LevelSettings.OnSettingsReady += SetSpawnManager;
        playerNumber = GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber;
        SetSpawnManager();
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetSpawnManager;
    }

    private void SetSpawnManager()
    {
        respawnManager = LevelSettings.Instance.RespawnManager;
    }

    public void MoveToRespawn()
    {
        if (respawnManager.MySpawnPoint(playerNumber) != null)
        {
            transform.position = respawnManager.MySpawnPoint(playerNumber).position;
        }
        else Debug.LogError("no spawn points!");
    }
}
