using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] private int playerNumber;

    [SerializeField] private GameObject[] avatarPrefabs;

    [SerializeField] private GameObject[] avatarImages;
    private int currentPrefab = 0;

    void Start()
    {
        playerManager = PlayerManager.Instance;
        SetCurrentPrefab();
    }

    public void SetPlayerAvatar()
    {
        playerManager.GetPlayerProfiles()[playerNumber].AvatarPrefab = avatarPrefabs[currentPrefab];
    }

    public void NextAvatar()
    {
        if (currentPrefab < avatarPrefabs.Length-1) currentPrefab++;
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
