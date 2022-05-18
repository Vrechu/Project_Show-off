using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Start()
    {
        respawnManager = RespawnManager.Instance;
    }

    public void MoveToRespawn()
    {
        if (respawnManager.CurrentRespawnPoint() != null)
        {
            transform.position = respawnManager.CurrentRespawnPoint().position;
        }
    }
}
