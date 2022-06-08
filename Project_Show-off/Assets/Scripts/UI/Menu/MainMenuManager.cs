using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject titleButton, mainMenuButton;

    public enum MenuScreen
    {
        Main, CharacterSelect, Title
    }  

    public MenuScreen ActiveScreen;

    private void Start()
    {
        SetMenuScreen("Title");
    }

    public void SetMenuScreen(string screenName)
    {
        switch (screenName)
        {
            case "Main":
                characterSelect.SetActive(false);
                title.SetActive(false);
                mainScreen.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(mainMenuButton);
                break;

            case "CharacterSelect":
                mainScreen.SetActive(false);
                title.SetActive(false);
                characterSelect.SetActive(true);
                break;

            case "Title":
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                title.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(titleButton);
                break;
        }
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        ScoreManager.Instance.ClearGlobalPlayerScores();
        ManageScene.Instance.ClearSelectedLevels();
        ManageScene.Instance.LoadRandomLevel();
    }
}
