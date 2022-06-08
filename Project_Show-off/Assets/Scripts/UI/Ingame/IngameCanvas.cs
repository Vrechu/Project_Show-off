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
    public bool InMenu = false;
    private UniversalInputs inputs = new UniversalInputs(0);

    private LevelEndManager levelEndManager;
    void Start()
    {
        CloseMenu();
        LevelSettings.OnSettingsReady += SetManager;
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
            timeText.text = levelEndManager.levelTimer.ToString();
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
        ingameMenu.SetActive(false);
        InMenu = false;
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        ManageScene.Instance.LoadScene("MainMenu");
    }
}
