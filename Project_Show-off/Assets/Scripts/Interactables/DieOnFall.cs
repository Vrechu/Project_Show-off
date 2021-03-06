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
            ScoreManager.Instance.SetLevelPlayerRank(other.GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerNumber, playersAlive -1);
            Destroy(other.gameObject);
            playersAlive--;
            if (playersAlive < 2) OnAllPlayersDead?.Invoke();
            SoundManager.Instance.PlayEffect(SoundManager.Instance.FallAlt);
        }
        else if (other.CompareTag("Fruit")) Destroy(other.gameObject);
    }
}
