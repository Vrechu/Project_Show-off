using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddPlayerMenu : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerInputs inputs;
    private bool[] controllerJoined = new bool[5];
    private int playersJoined = 0;

    [SerializeField] private MainMenuManager mainMenuManager;
    [SerializeField] private GameObject[] avatarSelectors, deleteOnEnable;
    [SerializeField] private CharacterSelection[] characterSelections;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float countdownTime = 6;
    [SerializeField] private float countdownTimer;

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
        GoBack();
        AddPlayer();
        CountDown();
    }

    public bool CheckLockedIn()
    {
        int locked = 0;
        if (playersJoined > 0)
        {
            for (int i = 0; i < playersJoined; i++)
            {
                if (characterSelections[i].LockedIn)
                {
                    locked++;
                }
            }
            if (locked == playersJoined) return true;
            else return false;
        }
        else return false;
    }

    public void StartCheck()
    {
        if (CheckLockedIn())
        {
            ScoreManager.Instance.ClearGlobalPlayerScores();
            ManageScene.Instance.ClearSelectedLevels();
            ManageScene.Instance.LoadScene("InfoScreen");
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
                if (!controllerJoined[i] && Input.GetAxis("CJoin" + (i + 1)) == 1)
                {
                    playerManager.NewControllerPlayer(i+1);
                    Debug.Log("inputs: " + playerManager.GetPlayerProfiles()[0].PlayerInputs);
                    avatarSelectors[playersJoined].SetActive(true);
                    deleteOnEnable[playersJoined].SetActive(false);
                    controllerJoined[i] = true;
                    playersJoined++;
                    Debug.Log("Controller joined: " + (i+1) + ", Player: " + playersJoined);
                }
            }

            if (Input.GetKeyDown(KeyCode.Y)
                && !controllerJoined[4])
            {
                playerManager.NewKeyboardPlayer(0);
                avatarSelectors[playersJoined].SetActive(true);
                deleteOnEnable[playersJoined].SetActive(false);
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

        for (int i = 0; i < deleteOnEnable.Length; i++)
        {
            deleteOnEnable[i].SetActive(true);
        }

        for (int i = 0; i < AvatarManager.Instance.avatarsPicked.Length; i++)
        {
            AvatarManager.Instance.avatarsPicked[i] = false;
        }
        playersJoined = 0;
        if (playerManager != null) playerManager.ClearPlayers();
    }

    public void SetAvatarPicked(int pickedAvatar, int player)
    {
        AvatarManager.Instance.avatarsPicked[pickedAvatar] = true;
        for (int i = 0; i < characterSelections.Length; i++)
        {
            if (player != characterSelections[i].playerNumber
                && characterSelections[i].currentPrefab == pickedAvatar)
            {
                characterSelections[i].NextAvatar();
            }
        }
    }

    private void CountDown()
    {
        if (CheckLockedIn())
        {
            if (countdownTimer > 1)
            {
                countdownTimer -= Time.deltaTime;

            }
            else StartCheck();
            timerText.text = "Starting " + ((int)countdownTimer).ToString();
        }
        else
        {
            countdownTimer = countdownTime;
            timerText.text = "";
        }
    }
}
