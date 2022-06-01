using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }
    private List<PlayerProfile> playerProfiles = new List<PlayerProfile>();
    [SerializeField] public int maxPlayers = 4;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else {
            Debug.LogError("more than one player manager!");
            Destroy(this); 
        }
    }

    public void NewControllerPlayer(int controllerNumber)
    {
        if (playerProfiles.Count < maxPlayers)
        {
            playerProfiles.Add(new PlayerProfile(playerProfiles.Count ,controllerNumber, new ControllerInputs(controllerNumber)));
        }
        else Debug.LogError("Maximum players reached!");
    }

    public void NewKeyboardPlayer(int controllerNumber)
    {
        if (playerProfiles.Count < maxPlayers)
        {
            playerProfiles.Add(new PlayerProfile(playerProfiles.Count, controllerNumber, new ControllerInputs(controllerNumber)));
        }
        else Debug.LogError("Maximum players reached!");
    }

    public List<PlayerProfile> GetPlayerProfiles()
    {
        return playerProfiles;
    }

    public void ClearPlayers()
    {
        playerProfiles.Clear();
    }
}
