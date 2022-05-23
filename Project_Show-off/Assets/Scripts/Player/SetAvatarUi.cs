using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAvatarUi : MonoBehaviour
{
    [SerializeField] private GameObject avatar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetAvatar()
    {
        foreach (PlayerProfile playerProfile in PlayerManager.Instance.GetPlayerProfiles())
        {
            playerProfile.SetAvatar(avatar);

        }
    }
}
