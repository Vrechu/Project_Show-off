using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerMenu : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerInputs inputs;
    private bool[] controllerJoined = new bool[5];
    private int playersJoined = 0;

    [SerializeField] private MainMenuManager mainMenuManager;
    [SerializeField] private GameObject[] avatarSelectors;
    [SerializeField] private CharacterSelection[] characterSelections;

    private void Start()
    {
        playerManager = PlayerManager.Instance;
        inputs = new UniversalInputs(0);
    }

    private void OnEnable()
    {
        ClearPlayers();        
    }

    void Update()
    {
        AddPlayer();
        CheckLockedIn();
        GoBack();
    }

    void CheckLockedIn()
    {
        int locked = 0;
        if (inputs.MenuPressed())
        {
            for (int i = 0; i < playersJoined; i++)
            {
                if (characterSelections[i].LockedIn)
                {
                    locked++;                    
                }
            }
            if (locked == playersJoined) mainMenuManager.StartGame();
        }
    }

    private void GoBack()
    {
        if (inputs.GrabPressed())
        {
            mainMenuManager.SetMenuScreen("Main");
            ClearPlayers();
        }

    }

    public void AddPlayer()
    {
        if (playerManager.GetPlayerProfiles().Count < playerManager.maxPlayers)
        {
            for (int i = 0; i < controllerJoined.Length-1; i++)
            {
                if (!controllerJoined[i] && Input.GetAxis("CMenu" + (i + 1)) == 1)
                {
                    playerManager.NewControllerPlayer(i+1);
                    Debug.Log("inputs: " + playerManager.GetPlayerProfiles()[0].PlayerInputs);
                    avatarSelectors[playersJoined].SetActive(true);
                    controllerJoined[i] = true;
                    playersJoined++;
                    Debug.Log("Controller joined: " + (i+1) + ", Player: " + playersJoined);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return)
                && !controllerJoined[4])
            {
                playerManager.NewKeyboardPlayer(0);
                avatarSelectors[playersJoined].SetActive(true);
                controllerJoined[4] = true;
                playersJoined++;
                Debug.Log("Keyboard joined, Player: " + playersJoined);
            }
        }
    }

    public void ClearPlayers()
    {
        for (int i = 0; i < controllerJoined.Length; i++)
        {
            controllerJoined[i] = false;
        }

        for (int i = 0; i < avatarSelectors.Length; i++)
        {
            avatarSelectors[i].SetActive(false);
        }

        playersJoined = 0;
        if (playerManager != null) playerManager.ClearPlayers();
    }
}
