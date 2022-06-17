using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scores = new TextMeshProUGUI[4];
    [SerializeField] private GameObject[] winner = new GameObject[4];
    private ScoreManager scoreManager;
    private PlayerManager playerManager;

    [SerializeField] private float countdownTimer = 4;
    private UniversalInputs inputs = new UniversalInputs(0);
    private bool canContinue = false;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject continuePanel;


    void Start()
    {
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;
        continuePanel.SetActive(false);
        SetWinner();
        ShowScores();
    }

    private void SetWinner()
    {
        for (int i = 0; i < winner.Length; i++)
        {
            winner[i].SetActive(false);
        }
        winner[scoreManager.TopPlayer()].SetActive(true);
    }

    private void ShowScores()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            scores[i].text = scoreManager.GlobalPlayerScores[i].ToString();
        }
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
            ManageScene.Instance.LoadScene("MainMenu");
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
