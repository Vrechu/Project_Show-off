using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }
    private List<PlayerProfile> playersProfiles = new List<PlayerProfile>();
    [SerializeField] private int maxPlayers = 4;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else {
            Debug.LogError("more than one player manager!");
            Destroy(this); 
        }
    }

    public void NewPlayer()
    {
        if (playersProfiles.Count < maxPlayers)
        {
            playersProfiles.Add(new PlayerProfile(playersProfiles.Count));
        }
        else Debug.LogError("Maximum players reached!");
    }

    public List<PlayerProfile> GetPlayerProfiles()
    {
        return playersProfiles;
    }
}