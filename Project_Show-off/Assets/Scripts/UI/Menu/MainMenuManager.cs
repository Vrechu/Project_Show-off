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
        if (SoundManager.Instance != null && !SoundManager.Instance.MusicSource.isPlaying)
        {
            SoundManager.Instance.PlayMusic(SoundManager.Instance.MainMenuMusic);
        }
    }

    public void SetMenuScreen(string screenName)
    {
        currentScreen = screenName;
        title.SetActive(false);
        mainScreen.SetActive(false);
        characterSelect.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        howTo.SetActive(false);

        switch (screenName)
        {
            case "Title":
                title.SetActive(true);
                break;

            case "Main":
                mainScreen.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainMenuButton);
                break;

            case "CharacterSelect":
                characterSelect.SetActive(true);
                break;

            case "Settings":
                settings.SetActive(true);
                break;

            case "Credits":
                credits.SetActive(true);
                break;

            case "HowTo":
                howTo.SetActive(true);
                break;

        }
        if (SoundManager.Instance != null) SoundManager.Instance.PlayEffect(SoundManager.Instance.Select);
    }    

    public void QuitGame()
    {
        SoundManager.Instance.PlayEffect(SoundManager.Instance.Select);
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
