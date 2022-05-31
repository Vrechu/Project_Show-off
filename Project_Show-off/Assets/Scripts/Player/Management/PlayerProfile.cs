using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps track of the player controls, score ID number, and inputs
/// </summary>
public class PlayerProfile
{
    readonly public int Number;
    private float score = 0;
    private GameObject avatar;
    public PlayerInputs PlayerInputs;
    public bool InScene = false;

    public PlayerProfile(int playerNumber, PlayerInputs inputs)
    {
        Number = playerNumber;
        score = 0;
        PlayerInputs = inputs;
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
