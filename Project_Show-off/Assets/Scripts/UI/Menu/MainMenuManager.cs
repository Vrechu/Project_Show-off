using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private GameObject title;

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
                break;
        }
    }    
}
