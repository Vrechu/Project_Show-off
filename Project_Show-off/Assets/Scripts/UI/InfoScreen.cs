using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] InfoPanels;
    [SerializeField] private float countdownTimer = 11;
    private UniversalInputs inputs = new UniversalInputs(0);
    private bool canContinue = false;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject continuePanel;


    private void Start()
    {
        continuePanel.SetActive(false);
        SetPanel();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.LoadingMusic);
    }

    private void Update()
    {
        CountDown();
        Continue();
    }

    private void SetPanel()
    {
        for (int i = 0; i < InfoPanels.Length; i++)
        {
            InfoPanels[i].SetActive(false);
        }
        InfoPanels[ManageScene.Instance.NextLevel].SetActive(true);
    }

    public void Continue()
    {
        if (canContinue && inputs.JumpPressed())
        {
            ManageScene.Instance.LoadNextLevel();
            SoundManager.Instance.PlayEffect(SoundManager.Instance.Select);
        }
    }

    private void CountDown()
    {
        if (!canContinue)
        {
            if (countdownTimer > 1)
            {
                countdownTimer -= Time.deltaTime;
                timerText.text = ((int)countdownTimer).ToString();
            }
            else 
            {
                canContinue = true;
                continuePanel.SetActive(true);
                timerText.text = "";
                SoundManager.Instance.PlayEffect(SoundManager.Instance.Return);
            }
        }
    }
}
