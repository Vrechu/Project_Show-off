using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacePlayers : MonoBehaviour
{
    private PlayerInputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
    }

    public void InstantiatePlayers()
    {
        inputManager.splitScreen = true;
        inputManager.EnableJoining();
        foreach (PlayerProfile playerProfile in PlayerManager.Instance.GetPlayerProfiles())
        {
            inputManager.playerPrefab = playerProfile.GetAvatar();
            inputManager.JoinPlayer();
        }
        inputManager.DisableJoining();
    }

}
