using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerpanel : MonoBehaviour
{

    [SerializeField] private GameObject[] avatarImages, playerIcons;
    [SerializeField] private int playerNumber;
    void Start()
    {
        SetAvatarImage();
        SetPlayerIcon();
    }

    private void SetPlayerIcon()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i].SetActive(false);
        }
        playerIcons[playerNumber].SetActive(true);
    }

    private void SetAvatarImage()
    {
        for (int i = 0; i < avatarImages.Length; i++)
        {
            avatarImages[i].SetActive(false);
        }
        if (playerNumber < PlayerManager.Instance.GetPlayerProfiles().Count)
        {
            avatarImages[PlayerManager.Instance.GetPlayerProfiles()[playerNumber].AvatarNumber].SetActive(true);
        }
    }
}
