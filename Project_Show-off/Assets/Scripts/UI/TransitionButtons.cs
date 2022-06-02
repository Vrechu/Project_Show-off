using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionButtons : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen, secondScreen;

    void Start()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
    }

    public void SecondScreen()
    {
        ScoreManager.Instance.ClearLevelPlayerScores();
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
    }

    public void NextLevel(string levelName)
    {
        ManageScene.Instance.LoadScene(levelName);
    }
}
