using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class TransitionButtons : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen;

    [SerializeField] private float countdownTimer = 4;
    private UniversalInputs inputs = new UniversalInputs(0);
    private bool canContinue = false;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject continuePanel;

    void Start()
    {
        continuePanel.SetActive(false);
        ManageScene.Instance.SetNextLevel();
    }

    private void Update()
    {
        CountDown();
        Continue();
    }

    public void Continue()
    {
        if (canContinue && inputs.JumpPressed())
        {
            if (ManageScene.Instance.NextLevel != 0) ManageScene.Instance.LoadScene("InfoScreen");
            else ManageScene.Instance.LoadNextLevel();
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
            }
        }
    }
}
