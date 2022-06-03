using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public static ManageScene Instance { get; set; }
    public string[] Levels;
    public string finalScreen = "FinalScreen";
    private bool[] selectedLevels;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
        selectedLevels = new bool[Levels.Length];
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadRandomLevel()
    {
        string level;
        level = RandomNextLevel();
        LoadScene(level);
        Debug.Log("Level loaded: " + level);
    }

    public string RandomNextLevel()
    {
        int random = Random.Range(0, Levels.Length);

        return UnpickedLevel(random, 0);
    }

    private string UnpickedLevel(int selectedNumber, int rolls = 0)
    {
        if (rolls < Levels.Length)
        {
            rolls++;
            if (!selectedLevels[selectedNumber])
            {
                selectedLevels[selectedNumber] = true;
                return Levels[selectedNumber];
            }
            else if (selectedNumber < Levels.Length - 1)
            {
                return UnpickedLevel(selectedNumber + 1, rolls);
            }
            else return UnpickedLevel(0, rolls);
        }
        else return finalScreen;
    }

    public void ClearSelectedLevels()
    {
        for (int i = 0; i < selectedLevels.Length; i++)
        {
            selectedLevels[i] = false;
        }
    }
}
