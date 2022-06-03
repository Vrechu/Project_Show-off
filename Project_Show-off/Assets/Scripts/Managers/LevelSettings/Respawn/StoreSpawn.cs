using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSpawn : MonoBehaviour
{
    private RespawnManager respawnManager;


    private void Start()
    {
        LevelSettings.OnSettingsReady += SetManager;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetManager;
    }

    private void SetManager()
    {
        respawnManager = LevelSettings.Instance.RespawnManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawnManager.spawns[other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber] = transform;
        }
    }
}
