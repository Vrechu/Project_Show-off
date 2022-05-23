using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile
{
    readonly public int number;
    private float score = 0;
    private GameObject avatar;

    public PlayerProfile(int playerNumber)
    {
        number = playerNumber;
        score = 0;
    }

    public void AddScore(float addedScore)
    {
        score += addedScore;
    }

    public float GetScore()
    {
        return score;
    }

    public void SetAvatar(GameObject newAvatar)
    {
        avatar = newAvatar;
    }

    public GameObject GetAvatar()
    {
        return avatar;
    }
}
