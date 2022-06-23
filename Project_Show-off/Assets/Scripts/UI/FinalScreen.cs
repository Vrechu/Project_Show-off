using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scores = new TextMeshProUGUI[4];
    [SerializeField] private GameObject[] crowns, playerPanels = new GameObject[4];
    private ScoreManager scoreManager;
    private PlayerManager playerManager;

    [SerializeField] private float countdownTimer = 4;
    private UniversalInputs inputs = new UniversalInputs(0);
    private bool canContinue = false;
    [SerializeField] private GameObject continuePanel;

    [SerializeField] private float distanceUP = 100;
    [SerializeField] private float moveSpeed = 100;
    private float panelHeight;
    private bool movedUP = false;

    void Start()
    {
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;

        for (int i = 0; i < playerPanels.Length; i++)
        {
            playerPanels[i].SetActive(false);
        }

        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            playerPanels[i].SetActive(true);
        }

        scoreManager.CalculateGlobalRanksFromScores();
        for (int i = 0; i < crowns.Length; i++)
        {
            crowns[i].SetActive(false);
        }

        SoundManager.Instance.PlayMusic(SoundManager.Instance.LoadingMusic);

        continuePanel.SetActive(false);
        ShowScores();
        panelHeight = playerPanels[0].transform.position.y;
        panelHeight += distanceUP;
    }

    private void SetWinner()
    {
        
        for (int i = 0; i < scoreManager.GlobalPlayerRanks.Length; i++)
        {
            if (scoreManager.GlobalPlayerRanks[i] == 0)
            {
                crowns[i].SetActive(true);
            }
        }
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
        MoveWinnerUp();
    }

    public void Continue()
    {
        if (canContinue && inputs.JumpPressed())
        {
            ManageScene.Instance.LoadScene("MainMenu");
            SoundManager.Instance.PlayEffect(SoundManager.Instance.Select);
        }
    }

    private void CountDown()
    {
        if (!canContinue)
        {
            if (countdownTimer > 0)
            {
                countdownTimer -= Time.deltaTime;
            }
        }
    }

    private void MoveWinnerUp()
    {
        if (!movedUP && countdownTimer < 0)
        {
            for (int i = 0; i < playerPanels.Length; i++)
            {
                if (scoreManager.GlobalPlayerRanks[i] == 0)
                {
                    if (playerPanels[i].transform.position.y < panelHeight)
                    {
                        playerPanels[i].transform.Translate(0, Time.deltaTime * moveSpeed, 0);
                    }
                    else
                    {
                        SetWinner();
                        canContinue = true;
                        continuePanel.SetActive(true);
                        SoundManager.Instance.PlayEffect(SoundManager.Instance.Victory);
                    }
                }
            }
        }
    }
}
