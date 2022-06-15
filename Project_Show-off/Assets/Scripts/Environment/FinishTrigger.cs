using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishTrigger : MonoBehaviour
{
    private ScoreManager scoreManager;
    private int playersFinished = 0;
    [SerializeField] private int[] scoresOnFinish = new int[4];
    private PlayerManager playerManager;
    private LevelEndManager levelEndManager;

    private void Start()
    {
        playerManager = PlayerManager.Instance;
        scoreManager = ScoreManager.Instance;
        LevelSettings.OnSettingsReady += SetLevelEndManager;
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetLevelEndManager;
    }

    private void SetLevelEndManager()
    {
        levelEndManager = LevelSettings.Instance.LevelEndManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int playerNumber = other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber;
            scoreManager.AddLevelPlayerScore(playerNumber, scoresOnFinish[playersFinished]);
            playersFinished++;
            CheckFinshedPlayers();
            Destroy(other.gameObject);
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
