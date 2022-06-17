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
        GameInstanceManager.OnManagerDone += ManagerSetup;
    }

    private void OnDestroy()
    {
        GameInstanceManager.OnManagerDone -= ManagerSetup;
    }

    private void ManagerSetup()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
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
            playerProfiles.Add(new PlayerProfile(playerProfiles.Count, controllerNumber, new KeyboardInputs(controllerNumber)));
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
