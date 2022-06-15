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
    public int NextLevel;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
        selectedLevels = new bool[Levels.Length];
        Levels[0] = finalScreen;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded: " + sceneName);
    }

    public void LoadNextLevel()
    {
        LoadScene(Levels[NextLevel]);
    }

    public void SetNextLevel()
    {
        NextLevel = RandomNextLevel();        
    }

    public int RandomNextLevel()
    {
        int random = Random.Range(1, Levels.Length);

        return UnpickedLevel(random);
    }

    private int UnpickedLevel(int selectedNumber, int rolls = 0)
    {
        if (rolls < Levels.Length-1)
        {
            rolls++;
            if (!selectedLevels[selectedNumber])
            {
                selectedLevels[selectedNumber] = true;
                return selectedNumber;
            }
            else if (selectedNumber < Levels.Length - 1)
            {
                return UnpickedLevel(selectedNumber + 1, rolls);
            }
            else return UnpickedLevel(1, rolls);
        }
        else return 0;
    }

    public void ClearSelectedLevels()
    {
        for (int i = 0; i < selectedLevels.Length; i++)
        {
            selectedLevels[i] = false;
        }
    }
}
