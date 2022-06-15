using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class IngameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject ingameMenu;
    [SerializeField] private GameObject firstSelected;

    [SerializeField] private GameObject[] playerUIObjects;

    public bool InMenu = false;
    private UniversalInputs inputs = new UniversalInputs(0);

    private LevelEndManager levelEndManager;
    void Start()
    {
        CloseMenu();
        LevelSettings.OnSettingsReady += SetManager;
        SetPlayerUI();
    }

    private void OnDestroy()
    {
        LevelSettings.OnSettingsReady -= SetManager;
    }

    private void SetManager()
    {
        levelEndManager = LevelSettings.Instance.LevelEndManager;
    }

    private void Update()
    {
        if (inputs.MenuPressed())
        {
            if (!InMenu) OpenMenu();
            else CloseMenu();
        }
    }

    private void FixedUpdate()
    {
        if (levelEndManager != null)
        {
            timeText.text = ((int)levelEndManager.levelTimer).ToString();
        }
    }

    private void SetPlayerUI()
    {
        for (int i = 0; i < playerUIObjects.Length; i++) 
        {
            playerUIObjects[i].SetActive(false);            
        }
        for (int i = 0; i < PlayerManager.Instance.GetPlayerProfiles().Count; i++)
        {
            playerUIObjects[i].SetActive(true);
        }
    }

    public void OpenMenu()
    {
        ingameMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
        InMenu = true;
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        ingameMenu.SetActive(false);
        InMenu = false;
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        PlayerManager.Instance.ClearPlayers();
        ManageScene.Instance.LoadScene("MainMenu");
    }
}
