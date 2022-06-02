using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public static ManageScene Instance { get; set; }

    private void Start()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError("more than one scene manager!");
            Destroy(this);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadRandomLevel()
    {
        string level;
        level = LevelOrderManager.Instance.RandomNextLevel();
        LoadScene(level);
        Debug.Log("Level loaded: " + level);
    }
}
