using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerMenu : MonoBehaviour
{
    private PlayerManager playerManager;
    private bool[] controllerJoined = new bool[5];

    [SerializeField] private GameObject[] avatarSelectors;

    void Start()
    {
        playerManager = PlayerManager.Instance;
        ClearPlayers();
    }


    void Update()
    {
        AddPlayer();
    }

    public void AddPlayer()
    {
        if (playerManager.GetPlayerProfiles().Count < playerManager.maxPlayers)
        {
            for (int i = 0; i < controllerJoined.Length-1; i++)
            {
                if (!controllerJoined[i] && Input.GetAxis("CJump" + (i + 1)) == 1)
                {
                    avatarSelectors[playerManager.GetPlayerProfiles().Count].SetActive(true);
                    playerManager.NewControllerPlayer(i+1);
                    controllerJoined[i] = true;
                    Debug.Log("Controller joined: " + (i+1) + ", Player: " + playerManager.GetPlayerProfiles().Count);
                }
            }

            if (Input.GetAxis("Jump") == 1
                && !controllerJoined[4])
            {
                avatarSelectors[playerManager.GetPlayerProfiles().Count].SetActive(true);
                playerManager.NewKeyboardPlayer(0);
                controllerJoined[4] = true;
                Debug.Log("Keyboard joined, Player: " + playerManager.GetPlayerProfiles().Count);
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

        playerManager.ClearPlayers();
    }
}
