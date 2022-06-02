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

    public string RandomNextLevel()
    {
        int random = Random.Range(0, Levels.Length);

        int selected = UnpickedLevel(random);
        selectedLevels[selected] = true;

        return Levels[selected];
    }

    private int UnpickedLevel(int selected)
    {
        if (!selectedLevels[selected])
        {
            return selected;
        }
        else if (selected < Levels.Length - 1)
        {
            return UnpickedLevel(selected + 1);
        }
        else return 0;
    }
}
