using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float[] playerScores;
    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.Instance;
    }

    public void SetPlayerScores()
    {
        for(int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            playerScores[i] = playerManager.GetPlayerProfiles()[i].GetScore();
        }
    }

    public void ClearPlayerSCores()
    {
        for (int i = 0; i < playerScores.Length; i++)
        {
            playerScores[i] = 0;
        }
    }
}
