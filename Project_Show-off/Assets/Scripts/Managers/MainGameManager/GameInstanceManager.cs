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
            Debug.Log("more than one Game Manager. New manager destroyed.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
