using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private RespawnManager respawnManager;

    private enum PlayerNumber
    {
        Player1, Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    private void Start()
    {
        respawnManager = RespawnManager.Instance;
    }

    public void MoveToRespawn()
    {
        if (respawnManager.CurrentRespawnPoint() != null)
        {
            switch (playerNumber)
            {
                case PlayerNumber.Player1:
                    transform.position = respawnManager.CurrentRespawnPoint().position;
                    break;

                case PlayerNumber.Player2:
                    transform.position = respawnManager.CurrentRespawnPoint().position + Vector3.right;
                    break;
            }
        }
    }
}
