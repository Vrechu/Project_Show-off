using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }
    private List<PlayerProfile> playerProfiles = new List<PlayerProfile>();
    [SerializeField] private int maxPlayers = 4;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else {
            Debug.LogError("more than one player manager!");
            Destroy(this); 
        }
    }

    public void NewControllerPlayer()
    {
        if (playerProfiles.Count < maxPlayers)
        {
            playerProfiles.Add(new PlayerProfile(playerProfiles.Count + 1, new ControllerInputs(playerProfiles.Count + 1)));
        }
        else Debug.LogError("Maximum players reached!");
    }

    public void NewKeyboardPlayer()
    {
        if (playerProfiles.Count < maxPlayers)
        {
            playerProfiles.Add(new PlayerProfile(playerProfiles.Count + 1, new KeyboardInputs(playerProfiles.Count + 1)));
        }
        else Debug.LogError("Maximum players reached!");
    }

    public List<PlayerProfile> GetPlayerProfiles()
    {
        return playerProfiles;
    }
}
