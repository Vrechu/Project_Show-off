using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen, characterSelect, title, settings, credits, howTo;
    [SerializeField] private GameObject mainMenuButton, settingsButton;
    private UniversalInputs inputs = new UniversalInputs(0);
    private string currentScreen;

    private void Start()
    {
        SetMenuScreen("Title");
    }

    private void Update()
    {
        ToMenu();
    }

    public void SetMenuScreen(string screenName)
    {
        currentScreen = screenName;
        switch (screenName)
        {
            case "Title":
                title.SetActive(true);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(false);
                break;

            case "Main":
                title.SetActive(false);
                mainScreen.SetActive(true);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(false);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainMenuButton);
                break;

            case "CharacterSelect":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(true);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(false);
                break;

            case "Settings":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(true);
                credits.SetActive(false);
                howTo.SetActive(false);
                break;

            case "Credits":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(true);
                howTo.SetActive(false);
                break;

            case "HowTo":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(true);
                break;

        }
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    void ToMenu() 
    { 
        if (inputs.BackPressed() && 
            (currentScreen == "Settings"
            || currentScreen == "Credits"
            || currentScreen == "HowTo"))
        {
            SetMenuScreen("Main");
        }
        if ((inputs.JumpPressed()
            || inputs.MenuPressed()
            || inputs.GrabPressed()
            || inputs.JoinPressed())           
            && currentScreen == "Title")
        {
            SetMenuScreen("Main");
        }
    }
}
