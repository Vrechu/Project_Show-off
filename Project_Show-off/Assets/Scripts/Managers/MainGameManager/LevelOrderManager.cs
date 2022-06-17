using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrderManager : MonoBehaviour
{
    public static LevelOrderManager Instance { get; set; }
    public string[] Levels;
    private bool[] selectedLevels;


    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        selectedLevels = new bool[Levels.Length];
    }

}
