using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private int playerNumber;

    [SerializeField] private GameObject[] avatarPrefabs;
    [SerializeField] private GameObject[] avatarImages;

    [SerializeField] private GameObject[] disabledWhenLocked;
    private int currentPrefab = 0;
    public PlayerInputs playerInputs;
    public bool LockedIn = false;
    //public bool switchedAvatar, pressedSelect, pressedBack = true;

    void Start()
    {
        playerManager = PlayerManager.Instance;
        SetCurrentPrefab();
    }

    private void Update()
    {
        SetImputs();
        NavigateButtons();
        NavigateJoySticks();
    }

    private void SetImputs()
    {
        if (playerInputs == null && playerManager.GetPlayerProfiles()[playerNumber].PlayerInputs != null)
            playerInputs = playerManager.GetPlayerProfiles()[playerNumber].PlayerInputs;        
    }

    private void NavigateButtons()
    {
        if (playerInputs.JumpPressed() && !LockedIn )
        {
            LockInAvatar();
        }
        if (playerInputs.BackPressed() && LockedIn)
        {
            UnlockAvatar();
        }
    }

    private void NavigateJoySticks()
    {
        if (!LockedIn)
        {
            switch (playerInputs.ChangedFrameDirection())
            {
                case 1:
                    NextAvatar();
                    break;
                case -1:
                    PreviousAvatar();
                    break;
            }
        }
    }

    public void LockInAvatar()
    {
        playerManager.GetPlayerProfiles()[playerNumber].AvatarPrefab = avatarPrefabs[currentPrefab];
        for (int i = 0; i < disabledWhenLocked.Length; i++)
        {
            disabledWhenLocked[i].SetActive(false);
        }
        LockedIn = true;
    }

    public void UnlockAvatar()
    {
        for (int i = 0; i < disabledWhenLocked.Length; i++)
        {
            disabledWhenLocked[i].SetActive(true);
        }
        LockedIn = false;
    }

    public void NextAvatar()
    {
        if (currentPrefab < avatarPrefabs.Length - 1) currentPrefab++;
        else currentPrefab = 0;
        SetCurrentPrefab();
    }

    public void PreviousAvatar()
    {
        if (currentPrefab > 0) currentPrefab--;
        else currentPrefab = avatarPrefabs.Length - 1;
        SetCurrentPrefab();
    }

    private void SetCurrentPrefab()
    {
        for (int i = 0; i < avatarPrefabs.Length; i++)
        {
            avatarImages[i].SetActive(false);
        }
        avatarImages[currentPrefab].SetActive(true);
    }

}
