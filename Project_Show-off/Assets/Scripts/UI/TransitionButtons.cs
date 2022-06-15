using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionButtons : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen, secondScreen, firstSelected, secondSelected ;

    void Start()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void SecondScreen()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(secondSelected);
        ScoreManager.Instance.ClearLevelPlayerScores();
        ScoreManager.Instance.ClearLevelPlayerRanks();
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
    }

    public void NextLevel()
    {
        ManageScene.Instance.SetNextLevel();
    }
}
