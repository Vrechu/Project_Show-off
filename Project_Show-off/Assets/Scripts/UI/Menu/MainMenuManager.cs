using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen, characterSelect, title, settings, credits, howTo;
    [SerializeField] private GameObject mainMenuButton, settingsButton, creditsButton, howToButton;

    private void Start()
    {
        SetMenuScreen("Title");
    }

    public void SetMenuScreen(string screenName)
    {
        switch (screenName)
        {
            case "Title":
                title.SetActive(true);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(false);

                EventSystem.current.SetSelectedGameObject(null);
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

                EventSystem.current.SetSelectedGameObject(null);
                break;

            case "Settings":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(true);
                credits.SetActive(false);
                howTo.SetActive(false);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(settingsButton);
                break;

            case "Credits":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(true);
                howTo.SetActive(false);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(creditsButton);
                break;

            case "HowTo":
                title.SetActive(false);
                mainScreen.SetActive(false);
                characterSelect.SetActive(false);
                settings.SetActive(false);
                credits.SetActive(false);
                howTo.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(howToButton);
                break;

        }
    }    

    public void QuitGame()
    {
        Application.Quit();
    }
}
