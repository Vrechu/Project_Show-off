using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnFall : MonoBehaviour
{
    public static event Action OnAllPlayersDead;
    private int playersAlive;

    private void Start()
    {
        playersAlive = PlayerManager.Instance.GetPlayerProfiles().Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player died: " + other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber 
                + ", position: " + playersAlive);
            ScoreManager.Instance.LevelPlayerRanks[other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber] = playersAlive;
            Destroy(other.gameObject);
            playersAlive--;
            if (playersAlive < 1) OnAllPlayersDead?.Invoke();
        }
        else Destroy(other.gameObject);
    }
}
