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
    public int AvatarNumber;
    public GameObject AvatarInstance;
    public PlayerInputs PlayerInputs;
    public bool InScene = false;

    public PlayerProfile(int playerNumber, int controllerNumber, PlayerInputs inputs)
    {
        PlayerNumber = playerNumber;
        ControllerNumber = controllerNumber;
        PlayerInputs = inputs;
    }
}
