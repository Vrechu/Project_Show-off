using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public static AvatarManager Instance { get; set; }

    public bool[] avatarsPicked = new bool[4];
    public GameObject[] AvatarPrefabs;
    public string[] AvatarNames;

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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
            for (int i = 0; i < avatarsPicked.Length; i++)
            {
                avatarsPicked[i] = false;
            }
        }

    
}
