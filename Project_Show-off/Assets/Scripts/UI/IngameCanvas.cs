using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private LevelEndManager levelEndManager;
    void Start()
    {
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

    private void FixedUpdate()
    {
        if (levelEndManager != null)
        {
            timeText.text = levelEndManager.levelTimer.ToString();
        }
    }
}
