using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceManager : MonoBehaviour
{
    public static GameInstanceManager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError("more than one Game Manager! new manager destroyed.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
