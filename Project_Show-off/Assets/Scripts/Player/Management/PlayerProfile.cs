using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps track of the player controls, score ID number, and inputs
/// </summary>
public class PlayerProfile
{
    readonly public int PlayerNumber;
    readonly public int ControllerNumber;
    private float score = 0;
    public GameObject AvatarPrefab;
    public GameObject avatar;
    public PlayerInputs PlayerInputs;
    public bool InScene = false;

    public PlayerProfile(int playerNumber, int controllerNumber, PlayerInputs inputs)
    {
        PlayerNumber = playerNumber;
        ControllerNumber = controllerNumber;
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
}
