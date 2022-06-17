using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceManager : MonoBehaviour
{
    public static GameInstanceManager Instance { get; set; }
    [SerializeField] private bool StartingPoint = false;
    public static event Action OnManagerDone;

    private void Start()
    {
        if (Instance == null)
        {
            Debug.Log("Game started.");
            Instance = this;
            OnManagerDone?.Invoke();
        }
        else if (StartingPoint)
        {
            Debug.Log("More than one Game Manager. Manager replaced.");
            Destroy(Instance.gameObject);
            Instance = this;
            OnManagerDone?.Invoke();
        }
        else
        {
            Debug.Log("More than one Game Manager. New manager destroyed.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
