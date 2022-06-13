using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private PlayerManager playerManager;
    public int playerNumber;
    [SerializeField] private AddPlayerMenu addPlayerMenu;

    [SerializeField] private GameObject[] avatarImages, disabledWhenLocked, enabledWhenLocked;
    public int currentPrefab = 0;
    public PlayerInputs playerInputs;
    public bool LockedIn = false;


    void Start()
    {
        playerManager = PlayerManager.Instance;
        SetCurrentPrefabImage();
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
        playerManager.GetPlayerProfiles()[playerNumber].AvatarPrefab = addPlayerMenu.avatarPrefabs[currentPrefab];
        for (int i = 0; i < disabledWhenLocked.Length; i++)
        {
            disabledWhenLocked[i].SetActive(false);
        }
        for (int i = 0; i < enabledWhenLocked.Length; i++)
        {
            enabledWhenLocked[i].SetActive(true);
        }
        LockedIn = true;
        addPlayerMenu.SetAvatarPicked(currentPrefab, playerNumber);
    }

    public void UnlockAvatar()
    {
        for (int i = 0; i < disabledWhenLocked.Length; i++)
        {
            disabledWhenLocked[i].SetActive(true);
        }
        for (int i = 0; i < enabledWhenLocked.Length; i++)
        {
            enabledWhenLocked[i].SetActive(false);
        }
        LockedIn = false;
    }

    public void NextAvatar()
    {
        if (currentPrefab < addPlayerMenu.avatarPrefabs.Length - 1) currentPrefab++;
        else currentPrefab = 0;
        SetCurrentPrefabImage();
        if (addPlayerMenu.avatarsPicked[currentPrefab])
        {
            NextAvatar();
        }
    }

    public void PreviousAvatar()
    {
        if (currentPrefab > 0) currentPrefab--;
        else currentPrefab = addPlayerMenu.avatarPrefabs.Length - 1;
        SetCurrentPrefabImage();
        if (addPlayerMenu.avatarsPicked[currentPrefab])
        {
            PreviousAvatar();
        }
    }

    private void SetCurrentPrefabImage()
    {
        for (int i = 0; i < avatarImages.Length; i++)
        {
            avatarImages[i].SetActive(false);
        }
        avatarImages[currentPrefab].SetActive(true);
    }

}
