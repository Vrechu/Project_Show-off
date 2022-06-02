using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishTrigger : MonoBehaviour
{
    private ScoreManager scoreManager;
    private int playersFinished = 0;
    [SerializeField] private float[] scoresOnFinish = new float[4];
    private PlayerManager playerManager;
    private LevelEndManager levelEndManager;

    private void Start()
    {
        levelEndManager = LevelSettings.Instance.LevelEndManager;
        playerManager = PlayerManager.Instance;
        scoreManager = ScoreManager.Instance;
        PlacePlayers.OnPlayerSpawn += SetPlayers;
    }

    private void OnDestroy()
    {
        PlacePlayers.OnPlayerSpawn -= SetPlayers;
    }

    private void SetPlayers()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int playerNumber = other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber;
            scoreManager.AddLevelPlayerScore(playerNumber, scoresOnFinish[playersFinished]);
            playersFinished++;
            CheckFinshedPlayers();
        }
    }

    private void CheckFinshedPlayers()
    {
        if(playersFinished >= playerManager.GetPlayerProfiles().Count)
        {
            levelEndManager.EndLevel();
        }
    }
}
